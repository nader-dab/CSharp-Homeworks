using System;
using System.Text;

public class Event : IComparable
{
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int dateComparison = this.date.CompareTo(other.date);
        int titleComparison = this.title.CompareTo(other.title);
        int locationComparison = this.location.CompareTo(other.location);

        if (dateComparison == 0)
        {
            if (titleComparison == 0)
            {
                return locationComparison;
            }
            else
            {
                return titleComparison;
            }
        }
        else
        {
            return dateComparison;
        }
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + this.title);
        if (this.location != null && this.location != string.Empty)
        {
            toString.Append(" | " + this.location);
        }

        return toString.ToString();
    }
}