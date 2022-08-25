using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DevelopmentTools
{
    public static class UnityEditorTools
    {
       public enum FilterTypes
       {
           AudioClip,
           Prefab,
           Sprite,
           Texture,
           Scene,
       }

       private static readonly Dictionary<FilterTypes, string> _fileFilters = new Dictionary<FilterTypes, string>
       {
           { FilterTypes.AudioClip, "t:AudioClip" },
           { FilterTypes.Prefab, "t:Prefab" },
           { FilterTypes.Sprite, "t:Sprite" },
           { FilterTypes.Texture, "t:Texture" },
           { FilterTypes.Scene, "t:Scene" }
       };

       public static List<T> Find<T>(string[] paths, FilterTypes filter) where T : Object
       {
#if UNITY_EDITOR
           return AssetDatabase.FindAssets(_fileFilters[filter], paths)
               .Select(AssetDatabase.GUIDToAssetPath)
               .Select(AssetDatabase.LoadAssetAtPath<T>).Where(asset => asset != null)
               .ToList();
#else
           return null;
#endif
       }
    }
}
