using FagweekendQ3.DataStore;
using StructureMap;
namespace FagweekendQ3 {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IAlbumStore>().Use<AlbumStore>();
                            x.For<IArtistStore>().Use<ArtistStore>();
                        });
            return ObjectFactory.Container;
        }
    }
}