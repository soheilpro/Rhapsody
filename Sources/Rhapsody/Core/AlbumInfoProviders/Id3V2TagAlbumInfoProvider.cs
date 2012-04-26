using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Rhapsody.Core.Tags.Id3v2;
using Rhapsody.Core.Tags.Id3v2.Frames;
using Rhapsody.Utilities;

namespace Rhapsody.Core.AlbumInfoProviders
{
    internal class Id3V2TagAlbumInfoProvider : IAlbumInfoProvider
    {
        public string Name
        {
            get
            {
                return "ID3 v2 Tag";
            }
        }

        public Image Icon
        {
            get
            {
                return null;
            }
        }

        public AlbumInfo GetAlbumInfo(Album album, Session session, Context context)
        {
            var albumInfo = new AlbumInfo();
            var artistNames = new List<string>();
            var albumNames = new List<string>();
            var releaseYears = new List<string>();
            var covers = new List<Picture>();

            foreach (var disc in album.Discs)
            {
                var discNames = new List<string>();

                foreach (var track in disc.Tracks)
                {
                    try
                    {
                        var tag = Id3Tagv2.Load(track.SourceFile.FullName);

                        if (tag == null)
                            continue;

                        var tpe1Frame = tag.Frames[Tpe1Frame.FrameId].FirstOrDefault() as Tpe1Frame;
                        var talbFrame = tag.Frames[TalbFrame.FrameId].FirstOrDefault() as TalbFrame;
                        var tyerFrame = tag.Frames[TyerFrame.FrameId].FirstOrDefault() as TyerFrame;
                        var tit2Frame = tag.Frames[Tit2Frame.FrameId].FirstOrDefault() as Tit2Frame;
                        var tsstFrame = tag.Frames[TsstFrame.FrameId].FirstOrDefault() as TsstFrame;
                        var apicFrame = tag.Frames[ApicFrame.FrameId].FirstOrDefault() as ApicFrame;

                        if (tpe1Frame != null && !string.IsNullOrEmpty(tpe1Frame.Text))
                            artistNames.Add(tpe1Frame.Text);

                        if (talbFrame != null && !string.IsNullOrEmpty(talbFrame.Text))
                            albumNames.Add(talbFrame.Text);

                        if (tyerFrame != null && !string.IsNullOrEmpty(tyerFrame.Text))
                            releaseYears.Add(tyerFrame.Text);

                        if (tit2Frame != null && !string.IsNullOrEmpty(tit2Frame.Text))
                            albumInfo.TrackNames[track] = tit2Frame.Text;

                        if (tsstFrame != null && !string.IsNullOrEmpty(tsstFrame.Text))
                            discNames.Add(tsstFrame.Text);

                        if (apicFrame != null && apicFrame.PictureType == PictureType.FrontCover)
                            covers.Add(apicFrame.Picture);
                    }
                    catch (NotSupportedException)
                    {
                    }
                }

                albumInfo.DiscNames[disc] = discNames.MostCommon();
            }

            albumInfo.ArtistName = artistNames.MostCommon();
            albumInfo.Name = albumNames.MostCommon();
            albumInfo.ReleaseYear = releaseYears.MostCommon();
            albumInfo.Cover = covers.FirstOrDefault();

            if (albumInfo.Name != null)
            {
                while (true)
                {
                    var match = Regex.Match(albumInfo.Name, @"^(?<name>.*) \[(?<mark>.*)\]$");

                    if (!match.Success)
                        break;

                    albumInfo.Name = match.Groups["name"].Value;

                    if (match.Groups["mark"].Value != "Damaged")
                        albumInfo.Type = match.Groups["mark"].Value;
                }
            }

            return albumInfo;
        }
    }
}
