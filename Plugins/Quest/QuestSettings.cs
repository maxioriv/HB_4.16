using System.Collections.Generic;
using System.ComponentModel;
using log4net;
using Newtonsoft.Json;
using Triton.Bot;
using Triton.Bot.Settings;
using Triton.Common;
using Logger = Triton.Common.LogUtilities.Logger;

namespace Quest
{
	/// <summary>Settings for the Quest plugin. </summary>
	public class QuestSettings : JsonSettings
	{
		private static readonly ILog Log = Logger.GetLoggerInstanceForType();

		private static QuestSettings _instance;

		/// <summary>The current instance for this class. </summary>
		public static QuestSettings Instance
		{
			get
			{
				return _instance ?? (_instance = new QuestSettings());
			}
		}

		/// <summary>The default ctor. Will use the settings path "Quest".</summary>
		public QuestSettings()
			: base(GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "Quest")))
		{
		}

		/// <summary>
		/// Returns a list of non-ignored custom decks.
		/// </summary>
		[JsonIgnore]
		public List<CustomDeckCache> UsableDecks
		{
			get
			{
				var decks = new List<CustomDeckCache>();
				foreach (var deck in MainSettings.Instance.CustomDecks)
				{
					if (!IgnoredDecks.Contains(deck.Name))
					{
						decks.Add(deck);
					}
				}
				return decks;
			}
		}

		private bool _stopAfterAllQuestsAreDone;
		private string _ignoreDeck1;
		private string _ignoreDeck2;
		private string _ignoreDeck3;
		private string _ignoreDeck4;
		private string _ignoreDeck5;
		private string _ignoreDeck6;
		private string _ignoreDeck7;
		private string _ignoreDeck8;
		private string _ignoreDeck9;
		private string _ignoreDeck10;
		private string _ignoreDeck11;
		private string _ignoreDeck12;
		private string _ignoreDeck13;
		private string _ignoreDeck14;
		private string _ignoreDeck15;
		private string _ignoreDeck16;
		private string _ignoreDeck17;

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck1
		{
			get
			{
				return _ignoreDeck1;
			}
			set
			{
				if (!value.Equals(_ignoreDeck1))
				{
					_ignoreDeck1 = value;
					NotifyPropertyChanged(() => IgnoreDeck1);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck2
		{
			get
			{
				return _ignoreDeck2;
			}
			set
			{
				if (!value.Equals(_ignoreDeck2))
				{
					_ignoreDeck2 = value;
					NotifyPropertyChanged(() => IgnoreDeck2);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck3
		{
			get
			{
				return _ignoreDeck3;
			}
			set
			{
				if (!value.Equals(_ignoreDeck3))
				{
					_ignoreDeck3 = value;
					NotifyPropertyChanged(() => IgnoreDeck3);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck4
		{
			get
			{
				return _ignoreDeck4;
			}
			set
			{
				if (!value.Equals(_ignoreDeck4))
				{
					_ignoreDeck4 = value;
					NotifyPropertyChanged(() => IgnoreDeck4);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck5
		{
			get
			{
				return _ignoreDeck5;
			}
			set
			{
				if (!value.Equals(_ignoreDeck5))
				{
					_ignoreDeck5 = value;
					NotifyPropertyChanged(() => IgnoreDeck5);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck6
		{
			get
			{
				return _ignoreDeck6;
			}
			set
			{
				if (!value.Equals(_ignoreDeck6))
				{
					_ignoreDeck6 = value;
					NotifyPropertyChanged(() => IgnoreDeck6);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck7
		{
			get
			{
				return _ignoreDeck7;
			}
			set
			{
				if (!value.Equals(_ignoreDeck7))
				{
					_ignoreDeck7 = value;
					NotifyPropertyChanged(() => IgnoreDeck7);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck8
		{
			get
			{
				return _ignoreDeck8;
			}
			set
			{
				if (!value.Equals(_ignoreDeck8))
				{
					_ignoreDeck8 = value;
					NotifyPropertyChanged(() => IgnoreDeck8);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck9
		{
			get
			{
				return _ignoreDeck9;
			}
			set
			{
				if (!value.Equals(_ignoreDeck9))
				{
					_ignoreDeck9 = value;
					NotifyPropertyChanged(() => IgnoreDeck9);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck10
		{
			get
			{
				return _ignoreDeck10;
			}
			set
			{
				if (!value.Equals(_ignoreDeck10))
				{
					_ignoreDeck10 = value;
					NotifyPropertyChanged(() => IgnoreDeck10);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck11
		{
			get
			{
				return _ignoreDeck11;
			}
			set
			{
				if (!value.Equals(_ignoreDeck11))
				{
					_ignoreDeck11 = value;
					NotifyPropertyChanged(() => IgnoreDeck11);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck12
		{
			get
			{
				return _ignoreDeck12;
			}
			set
			{
				if (!value.Equals(_ignoreDeck12))
				{
					_ignoreDeck12 = value;
					NotifyPropertyChanged(() => IgnoreDeck12);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck13
		{
			get
			{
				return _ignoreDeck13;
			}
			set
			{
				if (!value.Equals(_ignoreDeck13))
				{
					_ignoreDeck13 = value;
					NotifyPropertyChanged(() => IgnoreDeck13);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck14
		{
			get
			{
				return _ignoreDeck14;
			}
			set
			{
				if (!value.Equals(_ignoreDeck14))
				{
					_ignoreDeck14 = value;
					NotifyPropertyChanged(() => IgnoreDeck14);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck15
		{
			get
			{
				return _ignoreDeck15;
			}
			set
			{
				if (!value.Equals(_ignoreDeck15))
				{
					_ignoreDeck15 = value;
					NotifyPropertyChanged(() => IgnoreDeck15);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck16
		{
			get
			{
				return _ignoreDeck16;
			}
			set
			{
				if (!value.Equals(_ignoreDeck16))
				{
					_ignoreDeck16 = value;
					NotifyPropertyChanged(() => IgnoreDeck16);
				}
			}
		}

		/// <summary>
		/// A deck to ignore for quests.
		/// </summary>
		[DefaultValue("")]
		public string IgnoreDeck17
		{
			get
			{
				return _ignoreDeck17;
			}
			set
			{
				if (!value.Equals(_ignoreDeck17))
				{
					_ignoreDeck17 = value;
					NotifyPropertyChanged(() => IgnoreDeck17);
				}
			}
		}

		/// <summary>
		/// A collection of decks to not use for quests by name.
		/// </summary>
		[JsonIgnore]
		public List<string> IgnoredDecks
		{
			get
			{
				var names = new List<string>();
				if (!string.IsNullOrEmpty(IgnoreDeck1))
					names.Add(IgnoreDeck1);
				if (!string.IsNullOrEmpty(IgnoreDeck2))
					names.Add(IgnoreDeck2);
				if (!string.IsNullOrEmpty(IgnoreDeck3))
					names.Add(IgnoreDeck3);
				if (!string.IsNullOrEmpty(IgnoreDeck4))
					names.Add(IgnoreDeck4);
				if (!string.IsNullOrEmpty(IgnoreDeck5))
					names.Add(IgnoreDeck5);
				if (!string.IsNullOrEmpty(IgnoreDeck6))
					names.Add(IgnoreDeck6);
				if (!string.IsNullOrEmpty(IgnoreDeck7))
					names.Add(IgnoreDeck7);
				if (!string.IsNullOrEmpty(IgnoreDeck8))
					names.Add(IgnoreDeck8);
				if (!string.IsNullOrEmpty(IgnoreDeck9))
					names.Add(IgnoreDeck9);
				if (!string.IsNullOrEmpty(IgnoreDeck10))
					names.Add(IgnoreDeck10);
				if (!string.IsNullOrEmpty(IgnoreDeck11))
					names.Add(IgnoreDeck11);
				if (!string.IsNullOrEmpty(IgnoreDeck12))
					names.Add(IgnoreDeck12);
				if (!string.IsNullOrEmpty(IgnoreDeck13))
					names.Add(IgnoreDeck13);
				if (!string.IsNullOrEmpty(IgnoreDeck14))
					names.Add(IgnoreDeck14);
				if (!string.IsNullOrEmpty(IgnoreDeck15))
					names.Add(IgnoreDeck15);
				if (!string.IsNullOrEmpty(IgnoreDeck16))
					names.Add(IgnoreDeck16);
				if (!string.IsNullOrEmpty(IgnoreDeck17))
					names.Add(IgnoreDeck17);
				return names;
			}
		}

		/// <summary>
		/// Should the plugin stop the bot after all quests are done?
		/// </summary>
		[DefaultValue(true)]
		public bool StopAfterAllQuestsAreDone
		{
			get
			{
				return _stopAfterAllQuestsAreDone;
			}
			set
			{
				if (!value.Equals(_stopAfterAllQuestsAreDone))
				{
					_stopAfterAllQuestsAreDone = value;
					NotifyPropertyChanged(() => StopAfterAllQuestsAreDone);
				}
				Log.InfoFormat("[日常任务插件设置] 自动停止至所有日常任务完成 = {0}.", _stopAfterAllQuestsAreDone);
			}
		}
	}
}