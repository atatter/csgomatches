using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IUOW
    {
        //Save pending changes to the data store
        void Commit();

        //Get repo for type
        //T GetRepository<T>() where T : class;

        //Standard repos
        IEFRepository<Team> Teams { get;  }
        IEFRepository<Match> Matches { get;  }
        IEFRepository<Map> Maps { get;  }
        IEFRepository<MapInMatch> MapInMatches { get;  }
        IEFRepository<Comment> Comments { get;  }
        IEFRepository<Player> Players { get;  }

        //Cust repos
        //IPersonRepository Persons { get; }
    }
}
