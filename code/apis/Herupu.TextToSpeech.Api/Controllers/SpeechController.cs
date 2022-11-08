using Amazon.Polly.Model;
using Amazon.Polly;
using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using System.Xml.Linq;
using System.IO;

namespace Herupu.TextToSpeech.Api.Controllers
{
    [ApiController]
    [Route("api/speech")]
    public class SpeechController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Get(string texto)
        {
            try
            {
                if (string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))
                    throw new Exception("É obrigatório informar um texto para leitura.");

                //if (palavra.Split(" ").Length > 1)
                //    throw new Exception("Para ler mais de uma palavra utilize o método post.");

                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

                string accessKey = config.GetSection("AwsPolly.AccessKey").Value;
                string secreatKey = config.GetSection("AwsPolly.SecreatKey").Value;

                var credentials = new BasicAWSCredentials(accessKey, secreatKey);
                var polly = new AmazonPollyClient(credentials, RegionEndpoint.USWest2);

                var lexicon = polly.ListLexiconsAsync(new ListLexiconsRequest()).Result;

                List<string> lexicons = new List<string>();
                lexicon.Lexicons.ForEach(l => lexicons.Add(l.Name));

                var req = polly.SynthesizeSpeechAsync(new SynthesizeSpeechRequest
                {
                    LanguageCode = "pt-BR",
                    OutputFormat = "mp3",
                    SampleRate = "8000",
                    Text = texto,
                    TextType = "text",
                    VoiceId = "Camila",
                    Engine = "Standard",
                    LexiconNames = lexicons
                }).Result;

                Response.Clear();

                var meta = req.ResponseMetadata;
                var helper = new AudioHelper();

                string caminho = String.Concat(Directory.GetCurrentDirectory(), @"\Leitura", ".mp3") ;

                helper.SalvarMp3(req, caminho);
                
                Task.WaitAll();

                Response.ContentType = "audio/mpeg";

                return Ok(req.AudioStream);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
