
**Linux Ubuntu**
These are the things that are changed between it not working and workding

*References in DataAccess libraries*

```
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite.Core" Version="5.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite.NetTopologySuite" Version="5.0.10" />
<PackageReference Include="SQLitePCLRaw.bundle_sqlite3" Version="2.0.6" />
```

**installed**
These two were installed when not working
```
sudo apt-get install libsqlite3-mod-spatialite
sudo apt-get install sqlite3
```

Extra one installed when started working
```
sudo apt-get install libspatialite-dev
```
