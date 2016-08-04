using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;



namespace AALogger
{

	// public enum
	public enum LogLevel
	{
		DEBUG, VERBOSE, INFO, WARNING, ERROR, WTF, DEFAULT
	};


	public class AALog
	{
		// Internal Variables
		internal bool AmIDebugged = false;
		internal bool isColorLoggingEnabled = false;
		internal int MAX_BREAD_CRUMBS = 5;
		internal int MAX_LOGFILES = 5;
		internal Int64 maxFileSize = 5 * 1024 * 1024;
		internal LogLevel currentLogLevel = LogLevel.ERROR;
		internal String[] breadCrumbs = new String[5];
		internal String[] logFiles;
		String time;


		// public variables
		public bool isClientSideLoggingEnabled { get; set; }
		public bool isClientSideExportEnabled { get; set; }

		// Public Exposed Methods
		public void AAlogd(String format)
		{
			String className = getCallingClass();
			time = getCurrentTime();
			String message = getFullConsoleLog(LogLevel.DEBUG, className, format);
			addBreadCrumbs(message);
			String wholeMessage = time + message;
			saveData(wholeMessage);
			logR(wholeMessage, LogLevel.DEBUG);
		}
		public void AALogv(String format)
		{
			String className = getCallingClass();
			String message = getFullConsoleLog(LogLevel.VERBOSE, className, format);
			addBreadCrumbs(message);
			String wholeMessage = time + message;
			saveData(wholeMessage);
			logR(wholeMessage, LogLevel.DEBUG);
		}
		public void AALogi(String format)
		{
			String className = getCallingClass();
			String message = getFullConsoleLog(LogLevel.INFO, className, format);
			addBreadCrumbs(message);
			String wholeMessage = time + message;
			saveData(wholeMessage);
			logR(wholeMessage, LogLevel.DEBUG);
		}
		public void AALogw(String format)
		{
			String className = getCallingClass();
			String message = getFullConsoleLog(LogLevel.WARNING, className, format);
			addBreadCrumbs(message);
			String wholeMessage = time + message;
			saveData(wholeMessage);
			logR(wholeMessage, LogLevel.DEBUG);
		}
		public void AALoge(String format)
		{
			String className = getCallingClass();
			String message = getFullConsoleLog(LogLevel.ERROR, className, format);
			addBreadCrumbs(message);
			String wholeMessage = time + message;
			saveData(wholeMessage);
			logR(wholeMessage, LogLevel.DEBUG);
		}
		public void AALogWTF(String format)
		{
			String className = getCallingClass();
			String message = getFullConsoleLog(LogLevel.WTF, className, format);
			addBreadCrumbs(message);
			String wholeMessage = time + message;
			saveData(wholeMessage);
			logR(wholeMessage, LogLevel.DEBUG);

		}
		public void enableClientSideLogging(bool trueOrFalse)
		{
			isColorLoggingEnabled = trueOrFalse;
		}


		//Internal Methods
		// get current rank
		int getCurrentRank(LogLevel level)
		{
			switch (level)
			{
				case LogLevel.DEBUG:
					return 0;
				case LogLevel.VERBOSE:
					return 1;
				case LogLevel.INFO:
					return 2;
				case LogLevel.WARNING:
					return 3;
				case LogLevel.ERROR:
					return 4;
				case LogLevel.WTF:
					return 5;
				default:
					return 6;
			}
		}
		// check rank of the log level
		bool isLogLevelHigherRank(LogLevel level)
		{
			int currentRank = getCurrentRank(currentLogLevel);
			int newRank = getCurrentRank(level);
			if (currentRank >= newRank)
			{
				return true;
			}
			else {
				return false;
			};
		}
		// add bread crumbs
		void addBreadCrumbs(String Crumb)
		{
			if (breadCrumbs.Length >= MAX_BREAD_CRUMBS)
			{

				// remove object at index 0
			}

			breadCrumbs[0] = Crumb;
		}
		// get calling class
		String getCallingClass()
		{
			// review: get the name of the class
			//var star = System.Environment.
			//var stackTrace = new StackTrace();
			//var methodBase = stackTrace.GetFrame(1).GetMethod();
			//var Class = methodBase.ReflectedType;
			//var Namespace = Class.Namespace;         //Added finding the namespace
			//System.Diagnostics.Debug.WriteLine(Namespace + "." + Class.Name + "." + methodBase.Name);
			//string callingboy = StackTrace;
			//System.Diagnostics.Debug.WriteLine(callingboy);

			//MethodBase m1 = MethodBase.getHashCode();

			return "ViewController ";
		}
		String getCurrentTime()
		{
			DateTime time = DateTime.Now.ToLocalTime();
			string currentTime = (string.Format("{0}", time));
			return currentTime as String;
		}
		String getFullConsoleLog(LogLevel level, String className, String message)
		{
			String consoleLog;
			consoleLog = getConsoleLogprefix(level, className) + message;
			return consoleLog;
		}
		String getConsoleLogprefix(LogLevel level, String className)
		{
			String logLevelPrefix;
			//if (level != null) 
			//{
			// logLevelPrefix = "[ %@ ]" + level;
			//}
			//if (className != "")
			//{
			//	logLevelPrefix = " %@ : " + className;
			//}
			//else 
			//{
			logLevelPrefix = " " + className;
			//}
			return logLevelPrefix;
		}
		internal void logR(String message, LogLevel level)
		{
			// change color of string
			System.Diagnostics.Debug.WriteLine(message);

			if (isColorLoggingEnabled)
			{
				switch (level)
				{
					case LogLevel.DEBUG:

					case LogLevel.VERBOSE:

					case LogLevel.INFO:

					case LogLevel.WARNING:

					case LogLevel.ERROR:

					case LogLevel.WTF:

					default:
						return;
				}
			}

		}

		// FILE MANAGEMENT
		private string[] logFileArray ()
		{
			if (logFiles.Length == 0) { 
			}
			string[] arr = new string[] { "raja", "reddy"};
			return arr;
		}
		private string getActiveFileName() {
			var logArray = logFileArray();
			if (logArray.Length != 0)
			{
				var fileName = logArray[0] as String;
				return fileName;
			}
			else {
				return getnewLogFile();
			}
		}
		private string getnewLogFile() 
		{
			// update: save file on background thread
			String[] logFiles = new String[] { };
			logFiles = logFileArray();
			if (logFiles.Length >= MAX_LOGFILES) {
				removeOldFile();
			}

			return " ";
		}
		private void removeOldFile() { 
			// remove the last file at array
		}
		private bool isFileSizeExceeded() {
			return true;
		}
		private void saveData(String message)
		{
		#if __IOS__
			NSUserDefaults.StandardUserDefaults.SetString(message, "logsjhhhh"); 
       		NSUserDefaults.StandardUserDefaults.Synchronize ();
		#endif

		#if __ANDROID__

		#endif

		#if __WINDOWS__

		#endif

		}

		// Swipe gesture recogniser methods
		public void respondToUISwipeGesture_Up()
		{
			if (isClientSideExportEnabled)
			{
				var panGesture = new TapGestureRecognizer();
				panGesture.Tapped += (s, e) =>
				{
					
					System.Diagnostics.Debug.WriteLine("upswipe dragging is done");

				};

			}
		}
		public void respondToUISwipeGesture_Down() 
		{
			AAloggerUpSwipeView view = new AAloggerUpSwipeView();
		
		}
	}
}

