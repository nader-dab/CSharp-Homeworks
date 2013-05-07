using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 0;

    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("The score cannot be a negative number.");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        if (Score < MinScore || Score > MaxScore)
        {
            throw new ArgumentOutOfRangeException(string.Format("The score must be between {0} and {1}.", MinScore, MaxScore));
        }
        else
        {
            return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
        }
    }
}
