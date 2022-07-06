namespace EF
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
     

    internal class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.connectionString);

            sqlConnection.Open();

            // UNCOMMENT TO START THE SOLUTIONS

            // VillianNames(sqlConnection);
            // MinionNames(sqlConnection);
            // AddMinion(sqlConnection);
            // ChangeTownNameCasing(sqlConnection);
            // RemoveVillian(sqlConnection);
            // PrintAllMinionNames(sqlConnection);
            // IncreaseMinionAge(sqlConnection);
            // IncreaseAgeSP(sqlConnection);

            sqlConnection.Close();


        }

        public static void IncreaseAgeSP(SqlConnection connection)
        {

            int id = int.Parse(Console.ReadLine());

            var query = "EXEC usp_GetOlder @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            var query2 = "Select Name, Age FROM Minions WHERE Id = @Id";
            var command2 = new SqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@Id", id);

            var dataReader = command2.ExecuteReader();

            while (dataReader.Read())
            {
                var name = (string)dataReader["Name"];

                if (dataReader["Age"] is DBNull)
                {
                    Console.WriteLine($"{name}");
                }

                else
                {
                    Console.WriteLine($"{name} – {(short)dataReader["Age"]} years old");
                }

            }

            dataReader.Close();

        }

        public static void IncreaseMinionAge(SqlConnection connection)
        {

            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sqlQueries = new Dictionary<int, string>();
            sqlQueries.Add(1, "UPDATE Minions SET Age += 1 WHERE ID IN ({Id})");
            var updateCmd = new SqlCommand(sqlQueries[1], connection);
            var inputAsString = string.Join(",", input);
            
            
           
            updateCmd.AddArrayParameters("Id", input);
                      
            sqlQueries.Add(2, "UPDATE Minions SET Name = UPPER(LEFT(Name,1)) + RIGHT(Name,Len(Name)-1) WHERE ID IN ({Id})");
            var updateName = new SqlCommand(sqlQueries[2], connection);
            updateName.AddArrayParameters("Id", input);
            updateCmd.ExecuteNonQuery();
            updateName.ExecuteNonQuery();
            sqlQueries.Add(3, "Select Name,Age FROM Minions");
            var getAllMinionsCmd = new SqlCommand(sqlQueries[3], connection);
            var dataReader = getAllMinionsCmd.ExecuteReader();

            while (dataReader.Read())
            {
                string name = (string)dataReader["Name"];

                if (dataReader["Age"] is DBNull)
                {
                    Console.WriteLine($"{name}");
                }

                else
                {
                    Console.WriteLine($"{name} {(short)dataReader["Age"]}");
                }
            }

            dataReader.Close();

        }

        public static void PrintAllMinionNames(SqlConnection connection)
        {
            /*Write a program that prints all minion names from the minions table in the following order: first record, last record, first + 1, last - 1, first + 2, last - 2 … first + n, last - n. */

            string query = "SELECT NAME FROM MINIONS";
            var command = new SqlCommand(query, connection);
            using var dataReader = command.ExecuteReader();
            var list = new List<string>();
            while (dataReader.Read())
            {
                list.Add((string)dataReader["Name"]);

            }

            var list2 = list.TakeLast(list.Count / 2).ToList();
            list = list.Take(list.Count - list2.Count).ToList();
            list2.Reverse();
            var endList = new List<string>();
            for (int i = 0; i < list2.Count(); i++)
            {
                endList.Add(list[i]);
                endList.Add(list2[i]);
            }

            if (list.Count % 2 != 0)
            {
                endList.Add(list[list.Count - 1]);
            }

            Console.WriteLine(string.Join($"{Environment.NewLine}", endList));
            dataReader.Close();

        }

        public static void RemoveVillian(SqlConnection sqlConnection)
        {
            /*Write a program that receives the ID of a villain, deletes him from the database and releases his minions from serving to him. Print on two lines the name of the deleted villain in the format "<Name> was deleted." and the number of minions released in format "<MinionCount> minions were released.". Make sure all operations go as planned, otherwise do not make any changes in the database.
If there is no villain in the database with the given ID, print "No such villain was found.".
*/
            int id = int.Parse(Console.ReadLine());
            Dictionary<int, string> sqlQueries = new Dictionary<int, string>();
            sqlQueries.Add(1, "SELECT COUNT(*) FROM Villians WHERE ID = @Id");
            var sqlTran = sqlConnection.BeginTransaction();
            SqlCommand existsCmd = new SqlCommand(sqlQueries[1], sqlConnection, sqlTran);
            existsCmd.Parameters.AddWithValue("@Id", id);
            if ((int)existsCmd.ExecuteScalar() == 0)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            sqlQueries.Add(2, "DELETE FROM MinionsVillians WHERE VillianId = @Id");
            SqlCommand deleteFromMinionsVilliansCmd = new SqlCommand(sqlQueries[2], sqlConnection, sqlTran);
            deleteFromMinionsVilliansCmd.Parameters.AddWithValue("@Id", id);
            int minionsCount = deleteFromMinionsVilliansCmd.ExecuteNonQuery();
            sqlQueries.Add(3, "DELETE FROM Villians WHERE Id = @Id");
            sqlQueries.Add(4, "Select TOP(1) Name FROM Villians WHERE Id = @Id");
            var getVillianName = new SqlCommand(sqlQueries[4], sqlConnection, sqlTran);
            getVillianName.Parameters.AddWithValue("@Id", id);
            string villianName = (string)getVillianName.ExecuteScalar();
            var deleteFromVilliansCmd = new SqlCommand(sqlQueries[3], sqlConnection, sqlTran);
            deleteFromVilliansCmd.Parameters.AddWithValue("@Id", id);
            deleteFromVilliansCmd.ExecuteNonQuery();
            sqlTran.Commit();
            Console.WriteLine($"{villianName} was deleted.");
            Console.WriteLine($"{minionsCount} minions were released");


        }

        public static void ChangeTownNameCasing(SqlConnection sqlConnection)
        {
            /*Write a program that changes all town names to uppercase for a given country. 
     You will receive one line of input with the name of the country.
    Print the number of towns that were changed in the format "<ChangedTownsCount> town names were affected.". On a second line, print the names that were changed, separated by a comma and a space.
    If no towns were affected (the country does not exist in the database or has no cities connected to it), print "No town names were affected.".
*/

            string countryName = Console.ReadLine();

            var sqlQuery = "Update Towns " +
                            "SET Name = UPPER(Name) " +
                            "WHERE COUNTRYCODE = (SELECT Id FROM COUNTRIES WHERE Name = @Country)";

            var updateCmd = new SqlCommand(sqlQuery, sqlConnection);
            updateCmd.Parameters.AddWithValue("@Country", countryName);

            int changedTowns = updateCmd.ExecuteNonQuery();

            if (changedTowns == 0)
            {
                Console.WriteLine("No town names were affected.");
            }

            else
            {
                Console.WriteLine($"{changedTowns} town names were affected.");

                var countriesQuery = "SELECT Name " +
                                           "FROM TOWNS " +
                                           "WHERE CountryCode = (Select Id From COUNTRIES WHERE Name = @Country)";
                var sqlTrans = sqlConnection.BeginTransaction();
                var countriesCmd = new SqlCommand(countriesQuery, sqlConnection, sqlTrans);

                countriesCmd.Parameters.AddWithValue("@Country", countryName);
                using var dataReader = countriesCmd.ExecuteReader();
                var listOfCountries = new List<string>();
                while (dataReader.Read())
                {
                    listOfCountries.Add((string)dataReader["Name"]);
                }
                dataReader.Close();
                sqlTrans.Commit();
                Console.WriteLine($"[{string.Join(", ", listOfCountries)}]");

            }


        }

        public static void AddMinion(SqlConnection sqlConnection)
        {
            /* 
             * Write a program that reads information about a minion and its villain and adds it to the database. 
             * --In case the town of the minion is not in the database, insert it as well.
             * --In case the villain is not present in the database, add him too with a default evilness factor of "evil". 
             * --Finally set the new minion to be a servant of the villain. Print appropriate messages after each operation.*/

            //"Minion: <Name> <Age> <TownName>"

            //READ THE DATA
            string[] minionData = Console.ReadLine().Split();
            minionData = minionData.Skip(1).ToArray();
            string minionName = minionData[0];
            short minionAge = short.Parse(minionData[1]);
            string minionTown = minionData[2];

            string[] villianData = Console.ReadLine().Split();
            villianData = villianData.Skip(1).ToArray();
            string villianName = villianData[0];

            /// --- INSERT NEW TOWN AND VILLIAN IF THEY DON't EXIST
            InsertNewTown(sqlConnection, minionTown);
            InsertNewVillian(sqlConnection, villianName);

            /// -- Insert The Minion
            /// 

            InsertNewMinion(sqlConnection, minionName, minionAge, minionTown);

            //// ADD MINION TO VILLIAN
            ///
            AddMinionToVillian(sqlConnection, minionName, villianName);





        }



        public static void MinionNames(SqlConnection sqlConnection)
        {
            int villianId = int.Parse(Console.ReadLine());

            string MinionNamesQuery = "SELECT v.Name as vName, m.Name as mName,m.Age as mAge " +
                                       "FROM Villians as v " +
                                       "JOIN MinionsVillians as mv ON v.Id = mv.VillianId " +
                                       "JOIN Minions as m ON m.Id = mv.MinionId " +
                                       "WHERE mv.VillianId = @Id";

            string villianHasMinionsQuery = "SELECT Count(*) " +
                                       "FROM Villians as v " +
                                       "JOIN MinionsVillians as mv ON v.Id = mv.VillianId " +
                                       //"JOIN Minions as m ON m.Id = mv.MinionId " +
                                       "WHERE mv.VillianId = @Id";
            var minionCountCmd = new SqlCommand(villianHasMinionsQuery, sqlConnection);
            minionCountCmd.Parameters.AddWithValue("@Id", villianId);

            int countOfMinions = (int)minionCountCmd.ExecuteScalar();
            if (countOfMinions == 0)
            {
                string getVilianNameQuery = "SELECT Name " +
                                            "FROM Villians " +
                                            "WHERE Villians.Id = @Id";
                var getVillianNameCmd = new SqlCommand(getVilianNameQuery, sqlConnection);
                getVillianNameCmd.Parameters.AddWithValue("@Id", villianId);
                string? villianName = (string?)getVillianNameCmd.ExecuteScalar();
                Console.WriteLine($"Villian: {villianName}");
                Console.WriteLine("(no minions)");
            }



            var minionsNamesCmd = new SqlCommand(MinionNamesQuery, sqlConnection);
            minionsNamesCmd.Parameters.AddWithValue("@Id", villianId);
            using SqlDataReader minionsNamesReader = minionsNamesCmd.ExecuteReader();
            int row = 1;
            while (minionsNamesReader.Read())
            {
                if (row == 1)
                {
                    string villianName = (string)minionsNamesReader["vName"];
                    Console.WriteLine($"Villian: {villianName}");
                }

                string minionName = (string)minionsNamesReader["mName"];

                if (minionsNamesReader["mAge"] is DBNull)
                {
                    Console.WriteLine($"{row++}. {minionName}");
                }

                else
                {
                    short minionAge = (short)minionsNamesReader["mAge"];
                    Console.WriteLine($"{row++}. {minionName} {minionAge}");

                }



            }
        }

        public static void VillianNames(SqlConnection sqlConnection)
        {

            string villianNamesQuery = "SELECT v.Name as villianName,Count(*) as CountOfMinions " +
                                        "FROM Villians as v " +
                                        "JOIN MinionsVillians as mv ON v.Id = mv.VillianId " +
                                        "GROUP BY v.Name " +
                                        "HAVING COUNT(*) > 3 " +
                                        "ORDER BY CountOfMinions DESC";

            SqlCommand villianNamesCmd = new SqlCommand(villianNamesQuery, sqlConnection);

            using SqlDataReader villianNamesReader = villianNamesCmd.ExecuteReader();

            while (villianNamesReader.Read())
            {
                string vilianName = (string)villianNamesReader["villianName"];
                int villianMinionsCount = (int)villianNamesReader["CountOfMinions"];

                Console.WriteLine($"{vilianName} - {villianMinionsCount}");
            }
            villianNamesReader.Close();

        }

        private static void AddMinionToVillian(SqlConnection sqlConnection, string minionName, string villianName)
        {
            var findMinionId = "SELECT TOP(1) ID FROM MINIONS WHERE NAME = @Name";
            var findMinionCmd = new SqlCommand(findMinionId, sqlConnection);
            findMinionCmd.Parameters.AddWithValue("@Name", minionName);
            int minionId = (int)findMinionCmd.ExecuteScalar();

            var findVillianId = "SELECT TOP(1) ID FROM VILLIANS WHERE NAME = @Name";
            var findVillianCmd = new SqlCommand(findVillianId, sqlConnection);
            findVillianCmd.Parameters.AddWithValue("@Name", villianName);
            int villianId = (int)findVillianCmd.ExecuteScalar();


            var insertQuery = "INSERT INTO MinionsVillians " +
                              $"VALUES ({minionId},{villianId}) ";

            new SqlCommand(insertQuery, sqlConnection).ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");
        }

        private static void InsertNewMinion(SqlConnection sqlConnection, string minionName, short minionAge, string minionTown)
        {
            var command = new SqlCommand("SELECT TOP(1) ID " +
                                         "FROM TOWNS " +
                                         "WHERE Name = @Name", sqlConnection);
            command.Parameters.AddWithValue("@Name", minionTown);
            int townId = (int)command.ExecuteScalar();
            var insertEntityQuery = "INSERT INTO Minions (Name,Age,TownId)" +
                                       "VALUES " +
                                       $"(@Name,@Age,@TownId)";
            var insertEntityCmd = new SqlCommand(insertEntityQuery, sqlConnection);
            insertEntityCmd.Parameters.AddWithValue("@Name", minionName);
            insertEntityCmd.Parameters.AddWithValue("@Age", minionAge);
            insertEntityCmd.Parameters.AddWithValue("@TownId", townId);
            insertEntityCmd.ExecuteNonQuery();

        }

        private static void InsertNewVillian(SqlConnection sqlConnection, string villianName)
        {
            string queryToCheckEntityExists = "SELECT COUNT(*) " +
                                      "FROM Villians " +
                                      "WHERE Villians.Name = @Name";
            var command = new SqlCommand(queryToCheckEntityExists, sqlConnection);
            command.Parameters.AddWithValue("@Name", villianName);
            if (!((int)command.ExecuteScalar() > 0))
            {
                int? evilnessFactor = (int?)new SqlCommand("Select Id FROM EvilnessFactor WHERE Name = 'evil'", sqlConnection).ExecuteScalar();
                var insertEntityQuery = "INSERT INTO Villians (Name,EvilnessFactorId)" +
                                      "VALUES " +
                                      $"(@Name,{evilnessFactor})";
                var insertEntityCmd = new SqlCommand(insertEntityQuery, sqlConnection);
                insertEntityCmd.Parameters.AddWithValue("@Name", villianName);
                insertEntityCmd.ExecuteNonQuery();
                Console.WriteLine($"Villian {villianName} was added to the database.");
            }
        }

        private static void InsertNewTown(SqlConnection sqlConnection, string minionTown)
        {

            string queryToCheckEntityExists = "SELECT COUNT(*) " +
                                     "FROM Towns " +
                                     "WHERE Towns.Name = @Name";
            var command = new SqlCommand(queryToCheckEntityExists, sqlConnection);
            command.Parameters.AddWithValue("@Name", minionTown);
            if (!((int)command.ExecuteScalar() > 0))
            {
                var insertTownQuery = "INSERT INTO Towns (Name) " +
                                      "VALUES (@Town)";
                var insertTownCmd = new SqlCommand(insertTownQuery, sqlConnection);
                insertTownCmd.Parameters.AddWithValue("@Town", minionTown);
                insertTownCmd.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }
        }

      

        private static string AddArrayParameters(SqlCommand sqlCommand, string[] array, string paramName)
        {
            /* An array cannot be simply added as a parameter to a SqlCommand so we need to loop through things and add it manually. 
             * Each item in the array will end up being it's own SqlParameter so the return value for this must be used as part of the
             * IN statement in the CommandText.
             */
            var parameters = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                parameters[i] = string.Format("@{0}{1}", paramName, i);
                sqlCommand.Parameters.AddWithValue(parameters[i], array[i]);
            }

            return string.Join(", ", parameters);
        }

    }

}
