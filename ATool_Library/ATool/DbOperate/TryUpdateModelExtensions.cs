using System;
using System.Linq;
using System.Reflection;

namespace ATool.DbOperate
{
    public static class TryUpdateModelExtensions
    {
        //项目常用忽略字段
        private readonly static string[] _skipCommonProperties = new string[] { "Id", "IsDeleted", "CreateId", "CreateName", "CreateTime", "ModifyId", "ModifyName", "ModifyTime" };

        /// <summary>
        /// 相同类型的对象A和B，用B的属性值更新A的属性值，可自由定制
        /// </summary>
        /// <typeparam name="TModel">类型</typeparam>
        /// <param name="model">对象A</param>
        /// <param name="updateModel">对象B</param>
        /// <param name="skipIsNull">对象B属性值为空时，是否跳过赋值，默认不跳过</param>
        /// <param name="skipProperties">对象B部分属性值跳过赋值</param>
        public static void TryUpdateModelCommonCustom<TModel>(this TModel model, TModel updateModel, bool skipIsNull = false,
            params string[] skipProperties) where TModel : class
        {
            try
            {
                PropertyInfo[] tmodelPropertyInfo = model.GetType().GetProperties(); //源model
                PropertyInfo[] tUpdateModelPropertyInfo = updateModel.GetType().GetProperties(); //更新model

                for (int i = 0; i < tUpdateModelPropertyInfo.Length; i++)
                {
                    var tupdateModelName = tUpdateModelPropertyInfo[i].Name;
                    if (skipProperties.Contains(tupdateModelName)) continue;
                    var updateValue = tUpdateModelPropertyInfo[i].GetValue(updateModel);
                    if (skipIsNull && updateValue == null) continue;
                    tmodelPropertyInfo[i].SetValue(model, updateValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 不同类型的对象A和B，用B的属性值更新A的属性值，可自由定制
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TUpdateModel"></typeparam>
        /// <param name="model">对象A</param>
        /// <param name="updateModel">对象B</param>
        /// <param name="skipIsNull">对象B属性值为空时，是否跳过赋值，默认不跳过</param>
        /// <param name="skipProperties">对象B部分属性值跳过赋值</param>
        public static void TryUpdateModelDifferentCustom<TModel, TUpdateModel>(this TModel model, TUpdateModel updateModel, bool skipIsNull = false,
            params string[] skipProperties)
            where TModel : class
            where TUpdateModel : class
        {
            try
            {
                PropertyInfo[] tmodelPropertyInfo = model.GetType().GetProperties(); //源model
                PropertyInfo[] tUpdateModelPropertyInfo = updateModel.GetType().GetProperties(); //更新model

                foreach (var updateModelItem in tUpdateModelPropertyInfo)
                {
                    var tupdateModelName = updateModelItem.Name;
                    if (skipProperties.Contains(tupdateModelName)) continue;
                    var updateValue = updateModelItem.GetValue(updateModel);
                    if (skipIsNull && updateValue == null) continue;

                    foreach (var modelItem in tmodelPropertyInfo)
                    {
                        var modelName = modelItem.Name;
                        if (tupdateModelName == modelName)
                        {
                            modelItem.SetValue(model, updateValue);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 相同类型的对象A和B，用B的属性值更新A的属性值，已忽略Id和CreatedAndModified
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model">对象A</param>
        /// <param name="updateModel">对象B</param>
        /// <param name="skipIsNull">对象B属性值为空时，是否跳过赋值，默认不跳过</param>
        /// <param name="skipProperties">对象B部分属性值跳过赋值</param>
        public static void TryUpdateModel<TModel>(this TModel model, TModel updateModel, bool skipIsNull = false, params string[] skipProperties)
            where TModel : class
            => TryUpdateModelCommonCustom(model, updateModel, skipIsNull, skipProperties.Union(_skipCommonProperties).ToArray());

        /// <summary>
        /// 不同类型的对象A和B，用B的属性值更新A的属性值，已忽略Id和CreatedAndModified
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TUpdateModel"></typeparam>
        /// <param name="model">对象A</param>
        /// <param name="updateModel">对象B</param>
        /// <param name="skipIsNull">对象B属性值为空时，是否跳过赋值，默认不跳过</param>
        /// <param name="skipProperties">对象B部分属性值跳过赋值</param> 
        public static void TryUpdateDiffModel<TModel, TUpdateModel>(this TModel model, TUpdateModel updateModel, bool skipIsNull = false, params string[] skipProperties)
            where TModel : class
            where TUpdateModel : class
            => TryUpdateModelDifferentCustom(model, updateModel, skipIsNull, skipProperties.Union(_skipCommonProperties).ToArray());
    }
}
