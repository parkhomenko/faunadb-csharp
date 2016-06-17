﻿using FaunaDB.Types;
using FaunaDB.Utils;
using System;
using System.Reflection;

namespace FaunaDB.Query
{
    public partial struct Language
    {
        #region Basic Forms
        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#basic_forms">docs</see>. 
        /// This is the raw version. Usually it's easier to use the overload.
        /// </summary>
        public static Expr Let(Expr vars, Expr @in) =>
            Q("let", vars, "in", @in);

        /// <summary>
        /// Use a lambda expression to conveniently define let expressions.
        /// See the <see href="https://faunadb.com/documentation/queries#basic_forms">docs</see>.
        /// </summary>
        /// <example>
        /// <code>
        /// <c>Language.Let(1, a => a)</c> is equivalent to <c>Language.Let(new ObjectV("a", 1), Language.Var("a"))</c>
        /// </code>
        /// </example>
        public static Expr Let(Expr v0, Func<Expr, Expr> In)
        {
            ParameterInfo[] info = In.Method.GetParameters();
            string p0 = info[0].Name;

            return Let(
                Q(p0, v0),
                In(Var(p0)));
        }

        public static Expr Let(Expr v0, Expr v1, Func<Expr, Expr, Expr> In)
        {
            ParameterInfo[] info = In.Method.GetParameters();
            string p0 = info[0].Name;
            string p1 = info[1].Name;

            return Let(
                Q(p0, v0, p1, v1),
                In(Var(p0), Var(p1)));
        }

        public static Expr Let(Expr v0, Expr v1, Expr v2, Func<Expr, Expr, Expr, Expr> In)
        {
            ParameterInfo[] info = In.Method.GetParameters();
            string p0 = info[0].Name;
            string p1 = info[1].Name;
            string p2 = info[2].Name;

            return Let(
                Q(p0, v0, p1, v1, p2, v2),
                In(Var(p0), Var(p1), Var(p2)));
        }

        public static Expr Let(Expr v0, Expr v1, Expr v2, Expr v3, Func<Expr, Expr, Expr, Expr, Expr> In)
        {
            ParameterInfo[] info = In.Method.GetParameters();
            string p0 = info[0].Name;
            string p1 = info[1].Name;
            string p2 = info[2].Name;
            string p3 = info[3].Name;

            return Let(
                Q(p0, v0, p1, v1, p2, v2, p3, v3),
                In(Var(p0), Var(p1), Var(p2), Var(p3)));
        }

        public static Expr Let(Expr v0, Expr v1, Expr v2, Expr v3, Expr v4, Func<Expr, Expr, Expr, Expr, Expr, Expr> In)
        {
            ParameterInfo[] info = In.Method.GetParameters();
            string p0 = info[0].Name;
            string p1 = info[1].Name;
            string p2 = info[2].Name;
            string p3 = info[3].Name;
            string p4 = info[4].Name;

            return Let(
                Q(p0, v0, p1, v1, p2, v2, p3, v3, p4, v4),
                In(Var(p0), Var(p1), Var(p2), Var(p3), Var(p4)));
        }

        public static Expr Let(Expr v0, Expr v1, Expr v2, Expr v3, Expr v4, Expr v5, Func<Expr, Expr, Expr, Expr, Expr, Expr, Expr> In)
        {
            ParameterInfo[] info = In.Method.GetParameters();
            string p0 = info[0].Name;
            string p1 = info[1].Name;
            string p2 = info[2].Name;
            string p3 = info[3].Name;
            string p4 = info[4].Name;
            string p5 = info[5].Name;

            return Let(
                Q(p0, v0, p1, v1, p2, v2, p3, v3, p4, v4, p5, v5),
                In(Var(p0), Var(p1), Var(p2), Var(p3), Var(p4), Var(p5)));
        }

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#basic_forms">docs</see>. 
        /// </summary>
        public static Expr Var(string varName) =>
            Q("var", varName);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#basic_forms">docs</see>. 
        /// </summary>
        public static Expr If(Expr @if, Expr @then, Expr @else) =>
            Q("if", @if, "then", @then, "else", @else);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#basic_forms">docs</see>. 
        /// </summary>
        public static Expr Do(params Expr[] expressions) =>
            Q("do", Varargs(expressions));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#basic_forms">docs</see>. 
        /// This is the raw version. Usually it's easier to use an overload.
        /// </summary>
        public static Expr Lambda(Expr vars, Expr expr) =>
            Q("lambda", vars, "expr", expr);

        #endregion

        #region Collection Functions

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#collection_functions">docs</see>. 
        /// </summary>
        public static Expr Map(Expr collection, Expr lambda) =>
            Q("map", lambda, "collection", collection);

        public static Expr Map(Expr collection, Func<Expr, Expr> lambda) =>
            Map(collection, Lambda(lambda));

        public static Expr Map(Expr collection, Func<Expr, Expr, Expr> lambda) =>
            Map(collection, Lambda(lambda));

        public static Expr Map(Expr collection, Func<Expr, Expr, Expr, Expr> lambda) =>
            Map(collection, Lambda(lambda));

        public static Expr Map(Expr collection, Func<Expr, Expr, Expr, Expr, Expr> lambda) =>
            Map(collection, Lambda(lambda));

        public static Expr Map(Expr collection, Func<Expr, Expr, Expr, Expr, Expr, Expr> lambda) =>
            Map(collection, Lambda(lambda));

        public static Expr Map(Expr collection, Func<Expr, Expr, Expr, Expr, Expr, Expr, Expr> lambda) =>
            Map(collection, Lambda(lambda));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#collection_functions">docs</see>. 
        /// </summary>
        public static Expr Foreach(Expr collection, Expr lambda) =>
            Q("foreach", lambda, "collection", collection);

        public static Expr Foreach(Expr collection, Func<Expr, Expr> lambda) =>
            Foreach(collection, Lambda(lambda));

        public static Expr Foreach(Expr collection, Func<Expr, Expr, Expr> lambda) =>
            Foreach(collection, Lambda(lambda));

        public static Expr Foreach(Expr collection, Func<Expr, Expr, Expr, Expr> lambda) =>
            Foreach(collection, Lambda(lambda));

        public static Expr Foreach(Expr collection, Func<Expr, Expr, Expr, Expr, Expr> lambda) =>
            Foreach(collection, Lambda(lambda));

        public static Expr Foreach(Expr collection, Func<Expr, Expr, Expr, Expr, Expr, Expr> lambda) =>
            Foreach(collection, Lambda(lambda));

        public static Expr Foreach(Expr collection, Func<Expr, Expr, Expr, Expr, Expr, Expr, Expr> lambda) =>
            Foreach(collection, Lambda(lambda));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#collection_functions">docs</see>. 
        /// </summary>
        public static Expr Filter(Expr collection, Expr lambda) =>
            Q("filter", lambda, "collection", collection);

        public static Expr Filter(Expr collection, Func<Expr, Expr> lambda) =>
            Filter(collection, Lambda(lambda));

        public static Expr Filter(Expr collection, Func<Expr, Expr, Expr> lambda) =>
            Filter(collection, Lambda(lambda));

        public static Expr Filter(Expr collection, Func<Expr, Expr, Expr, Expr> lambda) =>
            Filter(collection, Lambda(lambda));

        public static Expr Filter(Expr collection, Func<Expr, Expr, Expr, Expr, Expr> lambda) =>
            Filter(collection, Lambda(lambda));

        public static Expr Filter(Expr collection, Func<Expr, Expr, Expr, Expr, Expr, Expr> lambda) =>
            Filter(collection, Lambda(lambda));

        public static Expr Filter(Expr collection, Func<Expr, Expr, Expr, Expr, Expr, Expr, Expr> lambda) =>
            Filter(collection, Lambda(lambda));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#collection_functions">docs</see>. 
        /// </summary>
        public static Expr Take(Expr number, Expr collection) =>
            Q("take", number, "collection", collection);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#collection_functions">docs</see>. 
        /// </summary>
        public static Expr Drop(Expr number, Expr collection) =>
            Q("drop", number, "collection", collection);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#collection_functions">docs</see>. 
        /// </summary>
        public static Expr Prepend(Expr elements, Expr collection) =>
            Q("prepend", elements, "collection", collection);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#collection_functions">docs</see>. 
        /// </summary>
        public static Expr Append(Expr elements, Expr collection) =>
            Q("append", elements, "collection", collection);
        #endregion

        #region Read Functions

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#read_functions">docs</see>. 
        /// </summary>
        public static Expr Get(Expr @ref, Expr ts = null) =>
            ts == null ? Q("get", @ref) : Q("get", @ref, "ts", ts);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#read_functions">docs</see>. 
        /// </summary>
        public static Expr Paginate(
            Expr set,
            Expr ts = null,
            Expr after = null,
            Expr before = null,
            Expr size = null,
            Expr events = null,
            Expr sources = null) =>
                new ObjectV(
                    ImmutableDictionary.Of(
                    "paginate", set,
                    "ts", ts,
                    "after", after,
                    "before", before,
                    "size", size,
                    "events", events,
                    "sources", sources));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#read_functions">docs</see>. 
        /// </summary>
        public static Expr Exists(Expr @ref, Expr ts = null) =>
            ts == null ? Q("exists", @ref) : Q("exists", @ref, "ts", ts);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#read_functions">docs</see>. 
        /// </summary>
        public static Expr Count(Expr set, Expr events = null) =>
            events == null ? Q("count", set) : Q("count", set, "events", events);
        #endregion

        #region Write Functions

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#write_functions">docs</see>. 
        /// </summary>
        public static Expr Create(Expr classRef, Expr @params) =>
            Q("create", classRef, "params", @params);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#write_functions">docs</see>. 
        /// </summary>
        public static Expr Update(Expr @ref, Expr @params) =>
            Q("update", @ref, "params", @params);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#write_functions">docs</see>. 
        /// </summary>
        public static Expr Replace(Expr @ref, Expr @params) =>
            Q("replace", @ref, "params", @params);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#write_functions">docs</see>. 
        /// </summary>
        public static Expr Delete(Expr @ref) =>
            Q("delete", @ref);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#write_functions">docs</see>. 
        /// </summary>
        public static Expr Insert(Expr @ref, Expr ts, Expr action, Expr @params) =>
            Q("insert", @ref, "ts", ts, "action", action, "params", @params);

        /// <summary>
        /// <see cref="Remove"/> that takes an <see cref="Event"/> object instead of separate parameters.
        /// </summary>
        public static Expr Remove(Expr @ref, Expr ts, Expr action) =>
            Q("remove", @ref, "ts", ts, "action", action);

        #endregion

        #region Sets
        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#sets">docs</see>. 
        /// </summary>
        public static Expr Match(Expr index, params Expr[] terms) =>
            Q("match", index, "terms", Varargs(terms));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#sets">docs</see>. 
        /// </summary>
        public static Expr Union(params Expr[] sets) =>
            Q("union", Varargs(sets));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#sets">docs</see>. 
        /// </summary>
        public static Expr Intersection(params Expr[] sets) =>
            Q("intersection", Varargs(sets));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#sets">docs</see>. 
        /// </summary>
        public static Expr Difference(params Expr[] sets) =>
            Q("difference", Varargs(sets));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#sets">docs</see>. 
        /// </summary>
        public static Expr Distinct(Expr set) =>
            Q("distinct", set);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#sets">docs</see>. 
        /// </summary>
        public static Expr Join(Expr source, Expr target) =>
            Q("join", source, "with", target);

        public static Expr Join(Expr source, Func<Expr, Expr> target) =>
            Join(source, Lambda(target));
        #endregion

        #region Authentication
        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#auth_functions">docs</see>. 
        /// </summary>
        public static Expr Login(Expr @ref, Expr @params) =>
            Q("login", @ref, "params", @params);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#auth_functions">docs</see>. 
        /// </summary>
        public static Expr Logout(Expr deleteTokens) =>
            Q("logout", deleteTokens);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#auth_functions">docs</see>. 
        /// </summary>
        public static Expr Identify(Expr @ref, Expr password) =>
            Q("identify", @ref, "password", password);
        #endregion

        #region String Functions

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#string_functions">docs</see>. 
        /// </summary>
        public static Expr Concat(Expr strings) =>
            Q("concat", strings);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#string_functions">docs</see>. 
        /// </summary>
        public static Expr Concat(Expr strings, Expr separator) =>
            Q("concat", strings, "separator", separator);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#string_functions">docs</see>. 
        /// </summary>
        public static Expr CaseFold(Expr @string) =>
            Q("casefold", @string);
        #endregion

        #region Time and Date

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#time_functions">docs</see>. 
        /// </summary>
        public static Expr Time(Expr time) =>
            Q("time", time);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#time_functions">docs</see>. 
        /// </summary>
        public static Expr Epoch(Expr number, Expr unit) =>
            Q("epoch", number, "unit", unit);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#time_functions">docs</see>. 
        /// </summary>
        public static Expr Date(Expr date) =>
            Q("date", date);
        #endregion

        #region Miscellaneous Functions

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr NextId() =>
            Q("next_id", NullV.Instance);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Equals(params Expr[] values) =>
            Q("equals", Varargs(values));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Contains(Expr path, Expr @in) =>
            Q("contains", path, "in", @in);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Select(Expr path, Expr @from, Expr @default = null) =>
            Q("select", path, "from", @from, "default", @default);

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Add(params Expr[] numbers) =>
            Q("add", Varargs(numbers));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Multiply(params Expr[] numbers) =>
            Q("multiply", Varargs(numbers));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Subtract(params Expr[] numbers) =>
            Q("subtract", Varargs(numbers));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Divide(params Expr[] numbers) =>
            Q("divide", Varargs(numbers));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Modulo(params Expr[] numbers) =>
            Q("modulo", Varargs(numbers));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>.
        /// </summary>
        public static Expr LT(params Expr[] values) =>
            Q("lt", Varargs(values));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>.
        /// </summary>
        public static Expr LTE(params Expr[] values) =>
            Q("lte", Varargs(values));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>.
        /// </summary>
        public static Expr GT(params Expr[] values) =>
            Q("gt", Varargs(values));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>.
        /// </summary>
        public static Expr GTE(params Expr[] values) =>
            Q("gte", Varargs(values));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr And(params Expr[] booleans) =>
            Q("and", Varargs(booleans));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Or(params Expr[] booleans) =>
            Q("or", Varargs(booleans));

        /// <summary>
        /// See the <see href="https://faunadb.com/documentation/queries#misc_functions">docs</see>. 
        /// </summary>
        public static Expr Not(Expr boolean) =>
            Q("not", boolean);
        #endregion

    }
}
