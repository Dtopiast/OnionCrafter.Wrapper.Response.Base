using OnionCrafter.Action.Response.Base;

namespace OnionCrafter.Wrapper.Response.Base
{
    /// <summary>
    /// Represents a base response schema.
    /// </summary>
    /// <typeparam name="TKey">The type of the action ID.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>

    public abstract class BaseResponseSchema<TKey, TResponseData>
      : IResponseSchema<TKey, TResponseData>

      where TResponseData : class, IResponseData
      where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <inheritdoc/>
        public TResponseData ResponseData { get; set; }

        /// <inheritdoc/>
        public bool Succeeded { get; set; }

        /// <inheritdoc/>

        public DateTime TimeStamp { get; set; }

        /// <inheritdoc/>
        public TKey ActionId { get; set; }

        /// <inheritdoc/>
        public string Message { get; set; }

        /// <inheritdoc/>
        public string FeatureCall { get; set; }

        /// <summary>
        /// Initializes a new instance of the BaseResponseSchema class.
        /// </summary>
        protected BaseResponseSchema()
        {
            ActionId = Activator.CreateInstance<TKey>();
            Succeeded = false;
            Message = string.Empty;
            FeatureCall = string.Empty;
            TimeStamp = DateTime.UtcNow;
            ResponseData = Activator.CreateInstance<TResponseData>();
        }

        /// <summary>
        /// Sets the error response message and returns the response schema instance.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>The response schema instance.</returns>
        public virtual IResponseSchema<TKey, TResponseData> ErrorResponse(string message)
        {
            if (message == string.Empty)
                Message = "Error";
            else
                Message = message;

            return this;
        }

        /// <summary>
        /// Sets the feature call associated with the response.
        /// </summary>
        /// <param name="featureName">The feature call name.</param>
        /// <returns>The response schema.</returns>
        public virtual IResponseSchema<TKey, TResponseData> SetFeatureCall(string featureName)
        {
            FeatureCall = featureName;
            return this;
        }

        /// <summary>
        /// Sets the message associated with the response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The response schema.</returns>
        public virtual IResponseSchema<TKey, TResponseData> SetMessage(string message)
        {
            if (Succeeded)
                SuccesFullyResponse(message);
            else
                ErrorResponse(message);
            return this;
        }

        /// <summary>
        /// Sets the response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        /// <returns>A boolean indicating the success of setting the response data.</returns>
        public virtual bool SetResponseData(TResponseData? data)
        {
            bool result = false;
            if (data != null)
            {
                ResponseData = data;
                SetSuccessfullyResult();
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Sets the response as a successful result.
        /// </summary>
        /// <returns>The response schema.</returns>
        public virtual IResponseSchema<TKey, TResponseData> SetSuccessfullyResult()
        {
            Succeeded = true;
            return this;
        }

        /// <summary>
        /// Creates a response schema with a success message.
        /// </summary>
        /// <param name="message">The success message.</param>
        /// <returns>The response schema.</returns>
        public virtual IResponseSchema<TKey, TResponseData> SuccesFullyResponse(string message)
        {
            if (message == string.Empty)
                Message = "Succeded";
            else
                Message = message;
            return this;
        }

        /// <inheritdoc/>
        public void SetActionId(TKey key)
        {
            ActionId = key;
        }

        /// <inheritdoc/>
        public abstract void CreateActionId();
    }
}