using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ecvLib.Core.ecvMapper
{
    public class ecvMapper<TSource, TDest> where TDest : new()
    {

        protected virtual void CopyMatchingProperties(TSource source, TDest dest)
        {
            foreach (var destProp in typeof(TDest).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanWrite))
            {
                var sourceProp =  typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.Name == destProp.Name && p.PropertyType == destProp.PropertyType).FirstOrDefault();
                if (sourceProp != null)
                {
                    destProp.SetValue(dest, sourceProp.GetValue(source, null), null);
                }
            }
        }

        protected readonly IList<Action<TSource, TDest>> mappings = new List<Action<TSource, TDest>>();

        public virtual void AddMapping(Action<TSource, TDest> mapping)
        {
            mappings.Add(mapping);
        }

        public virtual TDest MapObject(TSource source, TDest dest)
        {
            CopyMatchingProperties(source, dest);
            foreach (var action in mappings)
            {
                action(source, dest);
            }

            return dest;
        }

        //--List
        public virtual List<TDest> MapObjectList(List<TSource> sourceList, TDest dest)
        {
            List<TDest> destList = new List<TDest>(); //If need to pass values from sourc initialized object to destination initialized object remove this line. 
            foreach (var source in sourceList)
            {
                dest = new TDest();
                CopyMatchingProperties(source, dest);
                foreach (var action in mappings)
                {
                    action(source, dest);
                }
                destList.Add(dest); // add object into list
            }            
            return destList;
        }

        public virtual TDest CreateMappedObject(TSource source)
        {
            TDest dest = new TDest();
            return MapObject(source, dest);
        }

        //--List 
        public virtual List<TDest> CreateMappedObject(List<TSource> source)
        {
            TDest dest = new TDest();
            return MapObjectList(source, dest);
        }
        
    }
}


//public static object ecvMap(object srcObj)
//{
//    object dstObjectReturn = null;

//    if (srcObj != null)
//    {

//        dstObjectReturn = new TDest();
//        //--Go through each destination property
//        foreach (var propDest in dstObjectReturn.GetType().GetProperties())
//        {
//            //Find property in source based on destination name
//            var propSrc = srcObj.GetType().GetProperty(propDest.Name);
//            if (propSrc != null)
//            {
//                //Get value from source and assign it to destination
//                //Destination,Source
//                propDest.SetValue(dstObjectReturn, propSrc.GetValue(srcObj));
//            }
//        }
//    }

//    return dstObjectReturn;
//}