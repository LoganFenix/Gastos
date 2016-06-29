using EmoticonPlatzi.Models;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EmoticonPlatzi.Util
{
    public class EmotionHelper
    {
        public EmotionServiceClient emoClient;

        public EmotionHelper(string key)
        {
            emoClient = new EmotionServiceClient(key);

        }


        public async Task<EmoPicture> DetectAndExtractFacesAsync(Stream imageStream)
        {
           
           
            Emotion[] emotions = await emoClient.RecognizeAsync(imageStream);
            var emoPicture = new EmoPicture();


            emoPicture.Faces = EstracFaces(emotions, emoPicture);

                return emoPicture;
          
          
            

        }

        private ObservableCollection<EmoFace> EstracFaces(Emotion[] emotions,
            EmoPicture emoPicture)
        {
            var listaFaces = new ObservableCollection<EmoFace>();

            try
            {

                foreach (var emotion in emotions)
                {
                    var emoface = new EmoFace()
                    {
                        X = emotion.FaceRectangle.Left,
                        Y = emotion.FaceRectangle.Top,
                        Width = emotion.FaceRectangle.Width,
                        Height = emotion.FaceRectangle.Height,
                        Picture = emoPicture
                    };

                    emoface.Emotions = ProcessEmotions(emotion.Scores, emoface);
                    listaFaces.Add(emoface);
                }

                return listaFaces;
            }
            catch (Exception e)
            {
                return listaFaces;
            }
        }

        private ObservableCollection<EmoEmotion> ProcessEmotions(Scores scores, EmoFace emoface)
        {
            var emotionList = new ObservableCollection<EmoEmotion>();

            var properties = scores.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance );


            //var filterproperties = from p in properties
            //                       where p.PropertyType == typeof(float)
            //                       select p;


             var filterproperties = properties.Where(p => p.PropertyType == typeof(float));

            var emotype = EmoEmotionEnum.Undetermined;
            foreach(var prop in filterproperties)

            {

                if (!Enum.TryParse<EmoEmotionEnum>(prop.Name, out emotype))
                emotype = EmoEmotionEnum.Undetermined;
            

                var emoEmotion = new EmoEmotion();
                emoEmotion.Score = (float)prop.GetValue(scores);
                emoEmotion.EmotionType = emotype;
                emoEmotion.Face = emoface;

                emotionList.Add(emoEmotion);


            }

            return emotionList;
        }
    }
}