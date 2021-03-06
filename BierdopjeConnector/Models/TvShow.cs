namespace SemanticArchitecture.Subtitle.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using Chalk.SubtitlesManagement.Models;

    [Serializable()]
    public class TvShow : TvShowBase
    {
        [XmlArray("genres")]
        [XmlArrayItem("result")]
        public List<string> genres;

        public override List<string> Genres
        {
            get
            {
                return genres;
            }
        }
    }
}