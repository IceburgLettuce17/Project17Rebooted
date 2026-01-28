using OGClass = UnityEngine.Application;

namespace UnityExPJ17
{
	public class Application
	{
		public delegate void AdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled, string errorMsg);

		public delegate void LowMemoryCallback();

		public delegate void LogCallback(string condition, string stackTrace, LogType type);

		public static extern bool isPlaying => OGClass.isPlaying;

		public static extern bool isFocused => OGClass.isFocused;
		{
			get{return OGClass.isFocused;}
		}

		public static extern string buildGUID => OGClass.buildGUID;

		public static extern bool runInBackground => OGClass.runInBackground;
		{
			get;
			set;
		}

		public static extern bool isBatchMode => OGClass.isBatchMode;
		{
			get;
		}

		public static extern string dataPath
		{
			get;
		}

		public static extern string streamingAssetsPath
		{
			get;
		}

		public static extern string persistentDataPath
		{
			get;
		}

		public static extern string temporaryCachePath
		{
			get;
		}

		public static extern string absoluteURL
		{
			get;
		}

		public static extern string unityVersion
		{
			get;
		}

		public static extern string version
		{
			get;
		}

		public static extern string installerName
		{
			get;
		}

		public static extern string identifier
		{
			get;
		}

		public static extern ApplicationInstallMode installMode
		{
			get;
		}

		public static extern ApplicationSandboxType sandboxType
		{
			get;
		}

		public static extern string productName
		{
			get;
		}

		public static extern string companyName
		{
			get;
		}

		public static extern string cloudProjectId
		{
			get;
		}

		public static extern int targetFrameRate
		{
			get;
			set;
		}

		public static extern string consoleLogPath
		{
			get;
		}

		public static extern ThreadPriority backgroundLoadingPriority
		{
			get;
			set;
		}

		public static extern bool genuine
		{
			get;
		}

		public static extern bool genuineCheckAvailable
		{
			get;
		}

		public static RuntimePlatform platform => ShimManager.applicationShim.platform;

		public static bool isMobilePlatform => ShimManager.applicationShim.isMobilePlatform;

		public static bool isConsolePlatform => ShimManager.applicationShim.isConsolePlatform;

		public static SystemLanguage systemLanguage => ShimManager.applicationShim.systemLanguage;

		public static NetworkReachability internetReachability => ShimManager.applicationShim.internetReachability;

		public static bool isEditor => ShimManager.applicationShim.isEditor;

		public static event LowMemoryCallback lowMemory;

		public static event LogCallback logMessageReceived
		{
			add
			{
				s_LogCallbackHandler = (LogCallback)Delegate.Combine(s_LogCallbackHandler, value);
				SetLogCallbackDefined(defined: true);
			}
			remove
			{
				s_LogCallbackHandler = (LogCallback)Delegate.Remove(s_LogCallbackHandler, value);
			}
		}

		public static event LogCallback logMessageReceivedThreaded
		{
			add
			{
				s_LogCallbackHandlerThreaded = (LogCallback)Delegate.Combine(s_LogCallbackHandlerThreaded, value);
				SetLogCallbackDefined(defined: true);
			}
			remove
			{
				s_LogCallbackHandlerThreaded = (LogCallback)Delegate.Remove(s_LogCallbackHandlerThreaded, value);
			}
		}

		public static event UnityAction onBeforeRender
		{
			add
			{
				BeforeRenderHelper.RegisterCallback(value);
			}
			remove
			{
				BeforeRenderHelper.UnregisterCallback(value);
			}
		}

		public static event Action<bool> focusChanged;

		public static event Action<string> deepLinkActivated;

		public static event Func<bool> wantsToQuit;

		public static event Action quitting;

		public static event Action unloading;

		public static extern void Quit(int exitCode);

		public static void Quit()
		{
			Quit(0);
		}
		public static extern void Unload();

		public static bool CanStreamedLevelBeLoaded(int levelIndex)
		{
			return levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings;
		}

		public static extern bool CanStreamedLevelBeLoaded(string levelName);

		public static extern bool IsPlaying([NotNull("NullExceptionObject")] Object obj);

		public static extern string[] GetBuildTags();

		public static extern void SetBuildTags(string[] buildTags);

		public static extern bool HasProLicense();

		public static extern bool RequestAdvertisingIdentifierAsync(AdvertisingIdentifierCallback delegateMethod);

		public static extern void OpenURL(string url);

		public static extern StackTraceLogType GetStackTraceLogType(LogType logType);

		public static extern void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType);

		public static extern AsyncOperation RequestUserAuthorization(UserAuthorization mode);

		public static extern bool HasUserAuthorization(UserAuthorization mode);
	}
}
