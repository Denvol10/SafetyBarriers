using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SafetyBarriers.Models
{
    internal class RevitFamilyUtils
    {
        #region Список названий типоразмеров семейств
        public static ObservableCollection<FamilySymbolSelector> GetFamilySymbolNames(Document doc, IEnumerable<BuiltInCategory> builtInCategories)
        {
            var familySymbolNames = new ObservableCollection<FamilySymbolSelector>();
            var allFamilies = new FilteredElementCollector(doc).OfClass(typeof(Family)).OfType<Family>();
            var selectedFamilies = allFamilies.Where(f => builtInCategories.Any(bc => (int)bc == f.FamilyCategory.Id.IntegerValue));
            if (selectedFamilies.Count() == 0)
                return familySymbolNames;

            foreach (var family in selectedFamilies)
            {
                foreach (var symbolId in family.GetFamilySymbolIds())
                {
                    var familySymbol = doc.GetElement(symbolId);
                    familySymbolNames.Add(new FamilySymbolSelector(family.Name, familySymbol.Name));
                }
            }

            return familySymbolNames;
        }
        #endregion

        #region Получение типоразмера по имени
        public static FamilySymbol GetFamilySymbolByName(Document doc, FamilySymbolSelector familyAndSymbolName)
        {
            var familyName = familyAndSymbolName.FamilyName;
            var symbolName = familyAndSymbolName.SymbolName;

            Family family = new FilteredElementCollector(doc).OfClass(typeof(Family)).Where(f => f.Name == familyName).First() as Family;
            var symbolIds = family.GetFamilySymbolIds();
            foreach (var symbolId in symbolIds)
            {
                FamilySymbol fSymbol = (FamilySymbol)doc.GetElement(symbolId);
                if (fSymbol.get_Parameter(BuiltInParameter.SYMBOL_NAME_PARAM).AsString() == symbolName)
                {
                    return fSymbol;
                }
            }
            return null;
        }
        #endregion

        #region Получение семейства по имени
        public static Family GetFamilyByName(Document doc, FamilySymbolSelector familyAndSymbolName)
        {
            var familyName = familyAndSymbolName.FamilyName;
            Family family = new FilteredElementCollector(doc).OfClass(typeof(Family)).Where(f => f.Name == familyName).First() as Family;

            return family;
        }
        #endregion
    }
}
