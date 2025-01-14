﻿using System;
using System.Collections.Generic;
using System.Text;
using ShardingCore.Core;
using ShardingCore.Core.QueryRouteManagers;
using ShardingCore.Exceptions;

namespace ShardingCore.Extensions
{
    /*
    * @Author: xjm
    * @Description:
    * @Date: 2021/8/23 22:19:24
    * @Ver: 1.0
    * @Email: 326308290@qq.com
    */
    public static class ShardingRouteExtension
    {
        public static bool TryGetMustTail<TEntity>(this ShardingRouteContext shardingRouteContext, out HashSet<string> tail) where TEntity  : class,IShardingTable
        {
            return TryGetMustTail(shardingRouteContext,typeof(TEntity),out tail);
        }
        public static bool TryGetMustTail(this ShardingRouteContext shardingRouteContext,Type entityType, out HashSet<string> tail)
        {
            if (shardingRouteContext == null)
            {
                tail = null;
                return false;
            }
            if (!entityType.IsShardingTable())
                throw new ShardingCoreException($"sharding route entity type :{entityType.FullName} must impl {nameof(IShardingTable)}");
            if (!shardingRouteContext.Must.ContainsKey(entityType))
            {
                tail = null;
                return false;
            }

            tail = shardingRouteContext.Must[entityType];
            return true;
        }
    }
}
