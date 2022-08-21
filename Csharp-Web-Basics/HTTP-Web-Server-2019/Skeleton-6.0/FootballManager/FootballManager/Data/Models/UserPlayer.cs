namespace FootballManager.Data.Models
{
    public class UserPlayer
    {

        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        public int PlayerId { get; set; }

        public Player Player { get; set; } = null!;

        /*⦁	Has UserId – a string
        ⦁	Has User – a User object
        ⦁	Has PlayerId – an int
        ⦁	Has Player – a Player object
        */
    }
}