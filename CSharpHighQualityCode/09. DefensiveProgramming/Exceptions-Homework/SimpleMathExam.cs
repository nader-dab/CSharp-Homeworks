using System;

public class SimpleMathExam : Exam
{
    private const int TotalNumberOfProblems = 10;

    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("Problems solved must be a positive number.");
        }
        if (problemsSolved > TotalNumberOfProblems)
        {
            throw new ArgumentOutOfRangeException(string.Format("Problems solved cannot exceed {0}.", TotalNumberOfProblems));
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
