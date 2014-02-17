using System;

namespace Lette.ProjectEuler.WpfRunner.View
{
    public class ProblemViewModel
    {
        private const string _baseAddress = "http://projecteuler.net/problem=";

        public int Number { get; set; }
        public string Description { get; set; }
        public long? ExpectedAnswer { get; set; }
        public long? ProposedAnswer { get; set; }
        public string ElapsedTime { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsWrong { get; set; }
        public bool IsFaulted { get; set; }
        public bool IsInconclusive { get; set; }
        
        public Uri Link
        {
            get { return new Uri(_baseAddress + Number); }
        }
    }
}