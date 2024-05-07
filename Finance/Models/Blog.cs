namespace Finance.Models
{
	public class Blog
	{
		public class Post
		{
			public int Id { get; set; }
			public string Title { get; set; }
			public string Text { get; set; }
			public User Author { get; set; }
			public string Description { get; set; }
			public DateTime Date { get; set; }
			public Category Category { get; set; }

			public Post(int id, string title, string text, User author, string description, DateTime date, Category category)
			{
				Id = id;
				Title = title;
				Text = text;
				Author = author;
				Description = description;
				Date = date;
				Category = category;
			}
		}

		public class User
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Email { get; set; }

			public User(int id, string name, string email)
			{
				Id = id;
				Name = name;
				Email = email;
			}
		}
		//Blog, FinancialGoal, TaskItem, TextEditor, Transaction, Wish
		public class Category
		{
			public int Id { get; set; }
			public string Name { get; set; }

			public Category(int id, string name)
			{
				Id = id;
				Name = name;
			}
		}
	}
}
