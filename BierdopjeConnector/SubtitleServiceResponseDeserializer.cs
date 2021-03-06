// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubtitleServiceResponseDeserializer.cs" company="SemanticArchitecture http://www.semanticarchitecture.net">
//   SemanticArchitecture
// </copyright>
// <summary>
//   This class is responsible for deserializing the types from the xml response
//   from the subtitles service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SemanticArchitecture.Subtitle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    using Chalk.SubtitlesManagement.Models;

    using SemanticArchitecture.Subtitle.Models;

    /// <summary>
   /// This class is responsible for deserializing the types from the xml response
   /// from the subtitles service.
   /// </summary>
   public class SubtitleServiceResponseDeserializer
   {
      internal virtual TvShowBase GetTvShow(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ISingleTvShowResult>(xmlToParse, typeof(SingleTvShowResult)).TvShow;
      }

      internal virtual List<TvShow> GetTvShows(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvShowResult>(xmlToParse, typeof(FindByNamesResult)).TvShows;
      }

      internal TvShowEpisode GetTvShowEpisode(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvShowEpisode>(xmlToParse, typeof(SingleTvShowEpisodeResult)).Episode;
      }

      internal List<TvShowEpisode> GetTvShowEpisodes(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvEpisodes>(xmlToParse, typeof(TvShowEpisodeResult)).TvEpisodes;
      }

      internal List<TvShowEpisodeSubtitle> GetTvShowEpisodeSubtitles(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvShowEpisodeSubtitlesResult>(xmlToParse, typeof(TvShowEpisodeSubtitleResult)).TvShowEpisodeSubtitles;
      }

      private static TTypeToReturn DeserializeType<TTypeToReturn>(string xmlToParse, Type typeToDeserialize)
      {
         try
         {
            using (var stringReader = new StringReader(xmlToParse))
            {
               var xs = new XmlSerializer(typeToDeserialize);
               return (TTypeToReturn)xs.Deserialize(stringReader);
            }
         }
         catch (InvalidOperationException error)
         {
            throw new ArgumentException("The given xml is invalid and cannot be parsed.", "xmlToParse", error);
         }
      }

      private static void ValidateXmlToParse(string xmlToParse)
      {
         if (string.IsNullOrEmpty(xmlToParse))
         {
            throw new ArgumentNullException("xmlToParse", "The given xml cannot be null or empty.");
         }
      }
   }
}