using System;

using PArticulo;

namespace Org.InstitutoSerpis.Ad
{
	public interface IEntityDao<TEntity>
	{
		Articulo Load(object id);
	}
}

