using System.Text.Json;

namespace letscode_trabalho_ferroviaria.infrastructure.Repositories
{
    public class RepositoryBase<T>
    {
        private readonly string _pathFile;

        public RepositoryBase(string pathFile)
        {
            _pathFile = $@"{Directory.GetCurrentDirectory()}..\..\..\..\..\letscode_trabalho_ferroviaria.repository\Database\{pathFile}.json";
        }

        public virtual void Add(List<T> entities) => AddInJson(entities);

        public void AddLinkedList(T entity) => AddInJson(entity);

        private void AddInJson(object objects)
        {
            string json = JsonSerializer.Serialize(objects);
            File.WriteAllText(_pathFile, json);
        }

        public virtual List<T> GetAll()
        {
            using (StreamReader r = new StreamReader(_pathFile))
            {
                string json = r.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<T>();
                }

                return JsonSerializer.Deserialize<List<T>>(json);
            }
        }

        public T GetLinkedList()
        {
            using (StreamReader r = new StreamReader(_pathFile))
            {
                string json = r.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return default(T);
                }

                return JsonSerializer.Deserialize<T>(json);
            }
        }
    }
}
