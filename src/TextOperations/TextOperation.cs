using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Shabdkosh.TextOperations
{
    public class TextOperation: ITextOperation
    {
        private readonly string token = "609b538891053085d73a526a94fb3b0ae57ee63d";

        public Dictionary<string, int> Text2DictWordOccurance(string text)
        {
            string[] words = text.Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> occuranceOfAWord = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (occuranceOfAWord.ContainsKey(words[i]))
                {
                    int value = occuranceOfAWord[words[i]];
                    occuranceOfAWord[words[i]] = value + 1;
                }
                else
                {
                    occuranceOfAWord.Add(words[i], 1);
                }
            }

            return occuranceOfAWord;

        }


        public string GetDefinition(string keyword)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("https://owlbot.info/api/v4/dictionary/{0}/", keyword)))
                {

                    request.Headers.TryAddWithoutValidation("Authorization", string.Format("Token {0}", token));

                    using (HttpResponseMessage response = httpClient.SendAsync(request).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            return content.ReadAsStringAsync().Result;
                        }
                    }

                }
            }
        }
    }

    public interface ITextOperation
    {
        Dictionary<string, int> Text2DictWordOccurance(string text);

        string GetDefinition(string keyword);
    }

}
