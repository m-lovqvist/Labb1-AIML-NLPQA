using Azure;
using Azure.AI.Language.QuestionAnswering;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Labb1_AIML_NLPQA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string projectName = "Labb1-QA";
            string deploymentName = "production";

            Uri endpoint = new Uri("https://labb1-aiml-nlpqa.cognitiveservices.azure.com/");
            AzureKeyCredential credential = new AzureKeyCredential("09ad97e4148b46b6830c7a4efbba7681");

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);

            Console.WriteLine("Hello, I am your personal bot here to answer all your questions about Artificial Intelligence.");
            Console.WriteLine("Ask a question, type exit to quit.");

            while (true)
            {
                Console.Write("Q: ");
                string question = Console.ReadLine();
                if (question.ToLower() == "exit")
                {
                    break;
                }
                try
                {
                    Response<AnswersResult> response = client.GetAnswers(question, project);
                    foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
                    {
                        Console.WriteLine($"A:{answer.Answer}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Request error: {ex.Message}");
                }
            }

        }
    }
}