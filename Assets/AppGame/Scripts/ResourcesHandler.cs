using System;
using System.Collections.Generic;

[Serializable]
public class ResourcesHandler {
    List<Resource> resources = new List<Resource>();
    public void AddResource(Resource resource) {
        for (int i = 0; i  < resources.Count; i ++) {
            if (resources[i].id == resource.id) {
                resources[i].count += resource.count;
                return;
            }
        }
        
        resources.Add(resource);
    }

    public Resource[] GetResources() => resources.ToArray();
}