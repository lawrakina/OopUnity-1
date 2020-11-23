using System.Collections.Generic;
using View;


namespace Model
{
    public sealed class BonusesModel
    {
        private readonly List<BonusView> _allBonuses;

        public BonusesModel(List<BonusView> allBonuses)
        {
            _allBonuses = allBonuses;
        }

        public List<BonusView> AllBonuses => _allBonuses;
    }
}