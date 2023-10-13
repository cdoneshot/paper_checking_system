﻿using System;
using System.Collections.Generic;
using System.IO;

namespace paper_checking
{
    public class RunningEnv
    {
        public static readonly object EnvRunningLock = new object();
        public DateTime EnvTimestamp { get; }
        public MainForm UIContext { get; }

        public static class ProgramParam
        {
            public static readonly string SecurityKey = "Ubzrfax@3&Yl1rf&cw7ZE4zXsm8ZdIAtyJZ71L48f3yW*TXzylZq7Hqb1moG*xeQQnkFdkqYYXFfyPAS$CeETMw#1qDAPJehBM8";
            //public static readonly string SecurityKey = "";
            public static readonly int MaxWords = 99998;
            public static readonly string TxtPaperSourcePath = "txtPaperSource" + Path.DirectorySeparatorChar;
            public static readonly string ToCheckTxtPaperPath = "toCheckTxtPaper" + Path.DirectorySeparatorChar;
            public static readonly string ReportPath = "report" + Path.DirectorySeparatorChar;
            public static readonly string ReportDataPath = "reportData" + Path.DirectorySeparatorChar;
        }

        public class CheckParam
        {
            public int CheckWay { set; get; }
            public int CheckThreshold { set; get; }
            public bool Recover { set; get; }
            public bool StatisTable { set; get; }
            public string ToCheckPaperPath { set; get; }
            public string FinalReportPath { set; get; }
            public int MinBytes { set; get; }
            public int MinWords { set; get; }
            public string Blocklist { set; get; }
            public CheckParam()
            {
                CheckWay = 0;
                CheckThreshold = 13;
                Recover = false;
                StatisTable = true;
                ToCheckPaperPath = "";
                FinalReportPath = "";
                MinBytes = 1;
                MinWords = 1;
                Blocklist = "";
            }
        }

        public class CheckingParam
        {
            public LinkedList<string> ErrorPaperList { set; get; }
            public volatile int DllErrCount;
            public volatile int ThreadErrCount;
            public volatile bool IsFinisth = false;
            public CheckingParam()
            {
                DllErrCount = 0;
                ThreadErrCount = 0;
                ErrorPaperList = new LinkedList<string>();
            }
        }

        public class LibraryParam
        {
            public string PaperSourcePath { set; get; }
            public LibraryParam()
            {
                PaperSourcePath = "";
            }
        }

        public class SettingParam
        {
            public int CheckThreadCnt { set; get; }
            public int ConvertThreadCnt { set; get; }
            public bool SuportPdf { set; get; }
            public bool SuportDoc { set; get; }
            public bool SuportDocx { set; get; }
            public bool SuportTxt { set; get; }
            public SettingParam()
            {
                CheckThreadCnt = 1;
                ConvertThreadCnt = 1;
                SuportPdf = true;
                SuportDoc = true;
                SuportDocx = true;
                SuportTxt = true;
            }
        }

        public CheckParam CheckData { get; }
        public LibraryParam LibraryData { get; }
        public SettingParam SettingData { get; }
        public CheckingParam CheckingData { get; }

        public RunningEnv(MainForm mainForm)
        {
            CheckData = new CheckParam();
            CheckingData = new CheckingParam();
            LibraryData = new LibraryParam();
            SettingData = new SettingParam();
            UIContext = mainForm;
            EnvTimestamp = new DateTime();
        }

    }
}
