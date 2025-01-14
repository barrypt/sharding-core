using System.Linq;

namespace ShardingCore.Sharding.Abstractions
{
/*
* @Author: xjm
* @Description:
* @Date: Thursday, 28 January 2021 16:51:41
* @Email: 326308290@qq.com
*/
    public  interface IStreamMergeContextFactory
    {
        StreamMergeContext<T> Create<T>(IQueryable<T> queryable,IShardingDbContext shardingDbContext);
    }
}