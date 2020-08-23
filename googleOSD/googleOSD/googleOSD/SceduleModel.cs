using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;

/// <summary>
/// ProjectModel.edmx では書き換えられてしまう部分を別ファイル化
/// </summary>
namespace GoogleOSD {
	class SceduleModel {
	}

	/// <summary>
	/// 個々のスケジュールの読込み
	/// </summary>
	public class EventDataCollection : ObservableCollection<t_events> {
		public EventDataCollection()
		{
		}
	}

	public class EventContext : DbContext {
		public DbSet<t_events> Events { get; set; }
	}

	/// <summary>
	/// 案件情報の読込み
	/// </summary>
	public class ProjecDataCollection : ObservableCollection<t_project_base> {
		public ProjecDataCollection()
		{
		}
	}

	public class ProjectContext : DbContext {
		public DbSet<t_project_base> Projects { get; set; }
	}

}
