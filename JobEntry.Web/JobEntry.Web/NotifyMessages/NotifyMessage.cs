namespace JobEntry.Web.NotifyMessages
{
    public static class NotifyMessage
    {
        public static class Job
        {
            public static string Create(string title)
            {
                return $"The job posting title {title} has been successfully added!";
            }
            public static string Update(string title)
            {
                return $"The job posting title {title} has been successfully updated!";
            }
            public static string Delete(string title)
            {
                return $"The job posting title {title} has been successfully deleted!";
            }
        }
    }
}
