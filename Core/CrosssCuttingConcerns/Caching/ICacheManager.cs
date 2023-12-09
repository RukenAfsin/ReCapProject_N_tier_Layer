using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrosssCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);//getall vs getirmek istediğimde buna göre getirtiyorum
        object Get(string key);//yukarıdakinin farklı bir şekli
        void Add(string key, object value, int duration); //object yerine istediğini atarsın ve duration cachete ne kadar duracak?
        bool IsAdd(string key);
        void Remove(string key);    
        void RemoveByPattern(string pattern);//içinde bu pattern olanları cachele
    }
}
