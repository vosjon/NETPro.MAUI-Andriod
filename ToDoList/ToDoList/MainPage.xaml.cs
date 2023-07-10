using System.Windows.Input;
using ToDoList.Services;

namespace ToDoList;

public partial class MainPage : ContentPage
{
	private readonly TaskService taskService;

	public ICommand DeleteCommand { get; private set; }

	public MainPage()
	{
		InitializeComponent();
		taskService = new TaskService();
		DeleteCommand = new Command<string>(OnDeleteClicked);
		this.BindingContext = this;
	}

	private void OnAddTaskClicked(object sender, EventArgs e)
	{
		var task = new TaskItem
		{
			Id = Guid.NewGuid().ToString(),
			TaskName = TaskNameEntry.Text,
			IsDone = false,
		};

		taskService.AddTask(task);

		RefreshListView();
	}

	private void OnDeleteClicked(string taskId)
	{
		taskService.DeleteTask(taskId);
		RefreshListView();
	}

	private void OnTaskSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var listView = (ListView)sender;
		var task = (TaskItem)listView.SelectedItem;
		taskService.MarkTaskAsDone(task.Id);

		RefreshListView();
	}

	private void RefreshListView()
	{
		TasksListView.ItemsSource = taskService.GetTasks();
	}
	
}

