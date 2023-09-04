using OnionCrafter.Action.Base;
using OnionCrafter.Action.Response.Base;

namespace OnionCrafter.Wrapper.Response.Base
{
    /// <summary>
    /// Represents a response schema.
    /// </summary>
    /// <typeparam name="TKey">The type of the action ID.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>

    public interface IResponseSchema<TKey, TResponseData> :
        IBaseResponseSchema,
        IActionDetails<TKey>,
        IActionResponseData<TResponseData>,
        IActionResponseMessage
        where TResponseData : class, IResponseData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Gets or sets the feature call associated with the response.
        /// </summary>
        public string FeatureCall { get; protected set; }

        /// <summary>
        /// Handles an error response with the specified message.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> ErrorResponse(string message);

        /// <summary>
        /// Sets the feature call associated with the response.
        /// </summary>
        /// <param name="featureName">The feature call name.</param>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> SetFeatureCall(string featureName);

        /// <summary>
        /// Sets the message associated with the response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> SetMessage(string message);

        /// <summary>
        /// Sets the response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        /// <returns>A boolean indicating the success of setting the response data.</returns>
        public abstract bool SetResponseData(TResponseData? data);

        /// <summary>
        /// Sets the response as a successful result.
        /// </summary>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> SetSuccessfullyResult();

        /// <summary>
        /// Handles a successful response with the specified message.
        /// </summary>
        /// <param name="message">The success message.</param>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> SuccesFullyResponse(string message);
    }
}