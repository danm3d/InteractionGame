using UnityEngine;
using System.Collections;
using System;

public static class NameGenerator
{
	public static string[] gLastNames = new string[] {
		 "Wood",
		 "May",
		 "Gallagher",
		 "Steele",
		 "Solomon",
		 "Monroe",
		 "Bender",
		 "Hamilton",
		 "Chung",
		 "Chen",
		 "Melton",
		 "Hill",
		 "Pucket",
		 "Song",
		 "Wagner",
		 "McLaughlin",
		 "McNamara",
		 "Raynor",
		 "Moon",
		 "Griffin",
		 "Middleton",
		 "Hawkins",
		 "Goldstein",
		 "Watts",
		 "Lawrence"
};

	public static string[] gFirstNames = new string[] {
	 "Kristina",
	 "Paige",
	 "Sherri",
	 "Patrick",
	 "Elsie",
	 "Hazel",
	 "Malcom",
	 "Mario",
	 "Jerome",
	 "Neal",
	 "Jean",
	 "Alex",
	 "Christine",
	 "Crystal",
	 "Wesley",
	 "Claire",
	 "Wayne",
	 "John",
	 "George",
	 "Paul",
	 "Kin",
	 "Jim",
	 "Joshua",
	 "Annie",
	 "Gabriella",
	 "Eric",
	 "Dwight",
	 "Tim",
	 "Leon",
	 "Alan",
	 "Mark",
	 "Steve",
	 "Gary",
	 "Ray",
	 "Scott",
	 "Devin",
	 "Todd",
	 "Doug"
	};

	public static int GetRandomIndex(int length)
	{
		return new System.Random().Next(0, length);
	}
	public static string GetRandomFirstName()
	{
		return gFirstNames[GetRandomIndex(gFirstNames.Length)];
	}
	public static string GetRandomLastName()
	{
		return gLastNames[GetRandomIndex(gLastNames.Length)];
	}
}
