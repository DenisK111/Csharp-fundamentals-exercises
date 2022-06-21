using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> itemPool;
		public WarController()
		{
			party = new List<Character>();
			itemPool = new List<Item>();
		}
		public IReadOnlyCollection<Character> Party => party.AsReadOnly();
		public IReadOnlyCollection<Item> ItemPool => itemPool.AsReadOnly();

        public string JoinParty(string[] args)
		{
			var type = args[0];
			var name = args[1];

			var characters = new string[] { "Warrior", "Priest" }; 
            if (!characters.Any(x=>x == type))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }
            if (type=="Priest")
            {
				party.Add(new Priest(name));
            }

            else
            {
				party.Add(new Warrior(name));
            }

			return String.Format(SuccessMessages.JoinParty, name);

		}

		public string AddItemToPool(string[] args)
		{
			var name = args[0];
			string[] items = { "FirePotion", "HealthPotion" };

			if (!items.Any(x => x == name))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name));
			}

			if (name == items[0])
			{
				itemPool.Add(new FirePotion());
			}

            else
            {
				itemPool.Add(new HealthPotion());
            }

			return string.Format(SuccessMessages.AddItemToPool, name);
		}


		public string PickUpItem(string[] args)
		{
			var name = args[0];
			if (!Party.Any(x => x.Name == name))
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, name));

			}

			else if (ItemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			var item = itemPool[itemPool.Count - 1];
			itemPool.RemoveAt(itemPool.Count - 1);
			Party.First(x=>x.Name == name).Bag.AddItem(item);

			return string.Format(SuccessMessages.PickUpItem, name, item.GetType().Name);

		}

		public string UseItem(string[] args)
		{
			var charName = args[0];
			var itemName = args[1];

            if (!Party.Any(x=>x.Name == charName))
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, charName));
            }

			var character = Party.First(x => x.Name == charName);
			var item = character.Bag.GetItem(itemName);
			character.UseItem(item);
			return String.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
		}

		public string GetStats()
		{
			var sb = new StringBuilder();
			foreach (var character in Party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
			{
				sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead"));
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			var attackerName = args[0];
			var receiverName = args[1];

			if (!Party.Any(x => x.Name == attackerName))
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (!Party.Any(x => x.Name == receiverName))
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}
			var attacker = Party.First(x => x.Name == attackerName);
			

			if (!attacker.GetType().IsAssignableFrom(typeof(Warrior)))
            {
				throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));
            }
			attacker = attacker as Warrior;
			IAttacker attackerW = attacker as Warrior;
			var receiver = Party.First(x => x.Name == receiverName);
			attackerW.Attack(receiver);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(String.Format(SuccessMessages.AttackCharacter,attacker.Name,receiver.Name,attacker.AbilityPoints,receiver.Name,receiver.Health,receiver.BaseHealth,receiver.Armor,receiver.BaseArmor));
            if (!receiver.IsAlive)
            {
				sb.AppendLine(String.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }
			/* "{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiverHealth}/{receiverBaseHealth} HP and {receiverArmor}/{receiverBaseArmor} AP left!"
*/
			return sb.ToString().TrimEnd();



		}

		public string Heal(string[] args)
		{
			var healerName = args[0];
			var healerReceiverName = args[1];

			if (!Party.Any(x => x.Name == healerName))
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (!Party.Any(x => x.Name == healerReceiverName))
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerReceiverName)) ;
			}
			var healer = Party.First(x => x.Name == healerName);


			if (healer.GetType().Name == "Warrior")
			{
				throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}
			IHealer healerP = healer as Priest;
			var receiver = Party.First(x => x.Name == healerReceiverName);

			healerP.Heal(receiver);

			/* "{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!"*/

			return String.Format(SuccessMessages.HealCharacter, healerName, healerReceiverName, healer.AbilityPoints, healerReceiverName, receiver.Health);
		}
	}
}
