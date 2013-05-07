using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("The grade must be a positive number.");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("The min grade must be a positive number.");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("The min grade connot be large than the max grade.");
        }
        if (comments == null || string.IsNullOrEmpty(comments))
        {
            throw new ArgumentException("The comments must not be null or empty.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
