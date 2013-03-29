namespace Encog.App.Analyst
{
    using Encog.ML.Train;
    using System;

    public interface IAnalystListener
    {
        void Report(int total, int current, string message);
        void ReportCommandBegin(int total, int current, string name);
        void ReportCommandEnd(bool canceled);
        void ReportTraining(IMLTrain train);
        void ReportTrainingBegin();
        void ReportTrainingEnd();
        void RequestCancelCommand();
        void RequestShutdown();
        bool ShouldShutDown();
        bool ShouldStopCommand();
    }
}

