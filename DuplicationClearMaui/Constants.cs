﻿namespace DuplicationClearMaui;

public static class Constants
{
    public const string DatabaseFilename = "FileFindSQLite.db3";
    public const string sfLic = "MTM0MDc5OEAzMjMwMmUzNDJlMzBtV2JUbTNISy9za3AzVGlBLzFVTG12Z2pwME9HOFd4cUdrVTNCSW9URmhNPQ==";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}