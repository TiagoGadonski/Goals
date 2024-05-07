namespace Finance.Models
{
	public class TextEditor
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public string Author { get; set; }
		public DateTime Date { get; set; }
		public string Category { get; set; }

		public TextEditor(int id, string title, string text, string author, DateTime date, string category)
		{
			Id = id;
			Title = title;
			Text = text;
			Author = author;
			Date = date;
			Category = category;
		}
	}
}
