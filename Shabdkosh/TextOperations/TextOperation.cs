﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shabdkosh.TextOperations
{
    public class TextOperation: ITextOperation
    {
        private readonly string token = "609b538891053085d73a526a94fb3b0ae57ee63d";

        public Dictionary<string, int> Text2DictWordOccurance(string text)
        {
            Regex regex = new Regex("[^a-z]", RegexOptions.IgnoreCase);
            text = regex.Replace(text, @" ").ToLower();
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

        public async Task<string>  GetDefinitionAsync(string keyword)
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
                            return await content.ReadAsStringAsync();
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

        Task<string> GetDefinitionAsync(string keyword);

    }

}
