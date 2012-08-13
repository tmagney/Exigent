//This class is for source code reference only!

// Type: System.Exception
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace System
{
    /// <summary>
    /// Represents errors that occur during application execution.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ComDefaultInterface(typeof(_Exception))]
    [__DynamicallyInvokable]
    [Serializable]
    public class Exception : ISerializable, _Exception
    {
        [OptionalField]
        private static object s_EDILock = new object();
        private string _className;
        private MethodBase _exceptionMethod;
        private string _exceptionMethodString;
        internal string _message;
        private IDictionary _data;
        private Exception _innerException;
        private string _helpURL;
        private object _stackTrace;
        [OptionalField]
        private object _watsonBuckets;
        private string _stackTraceString;
        private string _remoteStackTraceString;
        private int _remoteStackIndex;
        private object _dynamicMethods;
        internal int _HResult;
        private string _source;
        private IntPtr _xptrs;
        private int _xcode;
        [OptionalField]
        private UIntPtr _ipForWatsonBuckets;
        [OptionalField(VersionAdded = 4)]
        private SafeSerializationManager _safeSerializationManager;
        private const int _COMPlusExceptionCode = -532462766;

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        /// 
        /// <returns>
        /// The error message that explains the reason for the exception, or an empty string("").
        /// </returns>
        /// <filterpriority>1</filterpriority>
        [__DynamicallyInvokable]
        public virtual string Message
        {
            [__DynamicallyInvokable]
            get
            {
                if (this._message != null)
                    return this._message;
                if (this._className == null)
                    this._className = this.GetClassName();
                return Environment.GetRuntimeResourceString("Exception_WasThrown", new object[1]
        {
          (object) this._className
        });
            }
        }

        /// <summary>
        /// Gets a collection of key/value pairs that provide additional user-defined information about the exception.
        /// </summary>
        /// 
        /// <returns>
        /// An object that implements the <see cref="T:System.Collections.IDictionary"/> interface and contains a collection of user-defined key/value pairs. The default is an empty collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        [__DynamicallyInvokable]
        public virtual IDictionary Data
        {
            [SecuritySafeCritical, __DynamicallyInvokable]
            get
            {
                if (this._data == null)
                    this._data = !Exception.IsImmutableAgileException(this) ? (IDictionary)new ListDictionaryInternal() : (IDictionary)new EmptyReadOnlyDictionaryInternal();
                return this._data;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Exception"/> instance that caused the current exception.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of Exception that describes the error that caused the current exception. The InnerException property returns the same value as was passed into the constructor, or a null reference (Nothing in Visual Basic) if the inner exception value was not supplied to the constructor. This property is read-only.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        [__DynamicallyInvokable]
        public Exception InnerException
        {
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._innerException;
            }
        }

        /// <summary>
        /// Gets the method that throws the current exception.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Reflection.MethodBase"/> that threw the current exception.
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public MethodBase TargetSite
        {
            [SecuritySafeCritical, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this.GetTargetSiteInternal();
            }
        }

        /// <summary>
        /// Gets a string representation of the immediate frames on the call stack.
        /// </summary>
        /// 
        /// <returns>
        /// A string that describes the immediate frames of the call stack.
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        [__DynamicallyInvokable]
        public virtual string StackTrace
        {
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this.GetStackTrace(true);
            }
        }

        /// <summary>
        /// Gets or sets a link to the help file associated with this exception.
        /// </summary>
        /// 
        /// <returns>
        /// The Uniform Resource Name (URN) or Uniform Resource Locator (URL).
        /// </returns>
        /// <filterpriority>2</filterpriority>
        [__DynamicallyInvokable]
        public virtual string HelpLink
        {
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._helpURL;
            }
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            set
            {
                this._helpURL = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the application or the object that causes the error.
        /// </summary>
        /// 
        /// <returns>
        /// The name of the application or the object that causes the error.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The object must be a runtime <see cref="N:System.Reflection"/> object</exception><filterpriority>2</filterpriority>
        [__DynamicallyInvokable]
        public virtual string Source
        {
            [__DynamicallyInvokable]
            get
            {
                if (this._source == null)
                {
                    StackTrace stackTrace = new StackTrace(this, true);
                    if (stackTrace.FrameCount > 0)
                    {
                        Module module = stackTrace.GetFrame(0).GetMethod().Module;
                        RuntimeModule runtimeModule = module as RuntimeModule;
                        if ((Module)runtimeModule == (Module)null)
                        {
                            ModuleBuilder moduleBuilder = module as ModuleBuilder;
                            if (!((Module)moduleBuilder != (Module)null))
                                throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeReflectionObject"));
                            runtimeModule = (RuntimeModule)moduleBuilder.InternalModule;
                        }
                        this._source = runtimeModule.GetRuntimeAssembly().GetSimpleName();
                    }
                }
                return this._source;
            }
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            set
            {
                this._source = value;
            }
        }

        internal UIntPtr IPForWatsonBuckets
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._ipForWatsonBuckets;
            }
        }

        internal object WatsonBuckets
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._watsonBuckets;
            }
        }

        internal string RemoteStackTrace
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._remoteStackTraceString;
            }
        }

        /// <summary>
        /// Gets or sets HRESULT, a coded numerical value that is assigned to a specific exception.
        /// </summary>
        /// 
        /// <returns>
        /// The HRESULT value.
        /// </returns>
        [__DynamicallyInvokable]
        public int HResult
        {
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._HResult;
            }
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            protected set
            {
                this._HResult = value;
            }
        }

        internal bool IsTransient
        {
            [SecuritySafeCritical]
            get
            {
                return Exception.nIsTransient(this._HResult);
            }
        }

        /// <summary>
        /// Occurs when an exception is serialized to create an exception state object that contains serialized data about the exception.
        /// </summary>
        protected event EventHandler<SafeSerializationEventArgs> SerializeObjectState
        {
            add
            {
                this._safeSerializationManager.SerializeObjectState += value;
            }
            remove
            {
                this._safeSerializationManager.SerializeObjectState -= value;
            }
        }

        static Exception()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class.
        /// </summary>
        [__DynamicallyInvokable]
        public Exception()
        {
            this.Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        [__DynamicallyInvokable]
        public Exception(string message)
        {
            this.Init();
            this._message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        [__DynamicallyInvokable]
        public Exception(string message, Exception innerException)
        {
            this.Init();
            this._message = message;
            this._innerException = innerException;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param><param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param><exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception><exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        [SecuritySafeCritical]
        protected Exception(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            this._className = info.GetString("ClassName");
            this._message = info.GetString("Message");
            this._data = (IDictionary)info.GetValueNoThrow("Data", typeof(IDictionary));
            this._innerException = (Exception)info.GetValue("InnerException", typeof(Exception));
            this._helpURL = info.GetString("HelpURL");
            this._stackTraceString = info.GetString("StackTraceString");
            this._remoteStackTraceString = info.GetString("RemoteStackTraceString");
            this._remoteStackIndex = info.GetInt32("RemoteStackIndex");
            this._exceptionMethodString = (string)info.GetValue("ExceptionMethod", typeof(string));
            this.HResult = info.GetInt32("HResult");
            this._source = info.GetString("Source");
            this._watsonBuckets = info.GetValueNoThrow("WatsonBuckets", typeof(byte[]));
            this._safeSerializationManager = info.GetValueNoThrow("SafeSerializationManager", typeof(SafeSerializationManager)) as SafeSerializationManager;
            if (this._className == null || this.HResult == 0)
                throw new SerializationException(Environment.GetResourceString("Serialization_InsufficientState"));
            if (context.State != StreamingContextStates.CrossAppDomain)
                return;
            this._remoteStackTraceString = this._remoteStackTraceString + this._stackTraceString;
            this._stackTraceString = (string)null;
        }

        /// <summary>
        /// When overridden in a derived class, returns the <see cref="T:System.Exception"/> that is the root cause of one or more subsequent exceptions.
        /// </summary>
        /// 
        /// <returns>
        /// The first exception thrown in a chain of exceptions. If the <see cref="P:System.Exception.InnerException"/> property of the current exception is a null reference (Nothing in Visual Basic), this property returns the current exception.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        [__DynamicallyInvokable]
        public virtual Exception GetBaseException()
        {
            Exception innerException = this.InnerException;
            Exception exception = this;
            for (; innerException != null; innerException = innerException.InnerException)
                exception = innerException;
            return exception;
        }

        [SecurityCritical]
        private MethodBase GetTargetSiteInternal()
        {
            if (this._exceptionMethod != (MethodBase)null)
                return this._exceptionMethod;
            if (this._stackTrace == null)
                return (MethodBase)null;
            this._exceptionMethod = this._exceptionMethodString == null ? this.GetExceptionMethodFromStackTrace() : this.GetExceptionMethodFromString();
            return this._exceptionMethod;
        }

        private string GetStackTrace(bool needFileInfo)
        {
            if (this._stackTraceString != null)
                return this._remoteStackTraceString + this._stackTraceString;
            if (this._stackTrace == null)
                return this._remoteStackTraceString;
            else
                return this._remoteStackTraceString + Environment.GetStackTrace(this, needFileInfo);
        }

        [FriendAccessAllowed]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        internal void SetErrorCode(int hr)
        {
            this.HResult = hr;
        }

        /// <summary>
        /// Creates and returns a string representation of the current exception.
        /// </summary>
        /// 
        /// <returns>
        /// A string representation of the current exception.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        [__DynamicallyInvokable]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public override string ToString()
        {
            return this.ToString(true);
        }

        private string ToString(bool needFileLineInfo)
        {
            string message = this.Message;
            string str = message == null || message.Length <= 0 ? this.GetClassName() : this.GetClassName() + ": " + message;
            if (this._innerException != null)
                str = str + " ---> " + this._innerException.ToString(needFileLineInfo) + Environment.NewLine + "   " + Environment.GetRuntimeResourceString("Exception_EndOfInnerExceptionStack");
            string stackTrace = this.GetStackTrace(needFileLineInfo);
            if (stackTrace != null)
                str = str + Environment.NewLine + stackTrace;
            return str;
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param><param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param><exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic). </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/></PermissionSet>
        [SecurityCritical]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            string str = this._stackTraceString;
            if (this._stackTrace != null)
            {
                if (str == null)
                    str = Environment.GetStackTrace(this, true);
                if (this._exceptionMethod == (MethodBase)null)
                    this._exceptionMethod = this.GetExceptionMethodFromStackTrace();
            }
            if (this._source == null)
                this._source = this.Source;
            info.AddValue("ClassName", (object)this.GetClassName(), typeof(string));
            info.AddValue("Message", (object)this._message, typeof(string));
            info.AddValue("Data", (object)this._data, typeof(IDictionary));
            info.AddValue("InnerException", (object)this._innerException, typeof(Exception));
            info.AddValue("HelpURL", (object)this._helpURL, typeof(string));
            info.AddValue("StackTraceString", (object)str, typeof(string));
            info.AddValue("RemoteStackTraceString", (object)this._remoteStackTraceString, typeof(string));
            info.AddValue("RemoteStackIndex", (object)this._remoteStackIndex, typeof(int));
            info.AddValue("ExceptionMethod", (object)this.GetExceptionMethodString(), typeof(string));
            info.AddValue("HResult", this.HResult);
            info.AddValue("Source", (object)this._source, typeof(string));
            info.AddValue("WatsonBuckets", this._watsonBuckets, typeof(byte[]));
            if (this._safeSerializationManager == null || !this._safeSerializationManager.IsActive)
                return;
            info.AddValue("SafeSerializationManager", (object)this._safeSerializationManager, typeof(SafeSerializationManager));
            this._safeSerializationManager.CompleteSerialization((object)this, info, context);
        }

        internal Exception PrepForRemoting()
        {
            string str;
            if (this._remoteStackIndex == 0)
                str = Environment.NewLine + (object)"Server stack trace: " + Environment.NewLine + this.StackTrace + Environment.NewLine + Environment.NewLine + "Exception rethrown at [" + (string)(object)this._remoteStackIndex + "]: " + Environment.NewLine;
            else
                str = this.StackTrace + (object)Environment.NewLine + Environment.NewLine + "Exception rethrown at [" + (string)(object)this._remoteStackIndex + "]: " + Environment.NewLine;
            this._remoteStackTraceString = str;
            ++this._remoteStackIndex;
            return this;
        }

        internal void InternalPreserveStackTrace()
        {
            string stackTrace = this.StackTrace;
            if (stackTrace != null && stackTrace.Length > 0)
                this._remoteStackTraceString = stackTrace + Environment.NewLine;
            this._stackTrace = (object)null;
            this._stackTraceString = (string)null;
        }

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static void GetStackTracesDeepCopy(Exception exception, out object currentStackTrace, out object dynamicMethodArray);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static void SaveStackTracesFromDeepCopy(Exception exception, object currentStackTrace, object dynamicMethodArray);

        [SecuritySafeCritical]
        internal object DeepCopyStackTrace(object currentStackTrace)
        {
            if (currentStackTrace != null)
                return Exception.CopyStackTrace(currentStackTrace);
            else
                return (object)null;
        }

        [SecuritySafeCritical]
        internal object DeepCopyDynamicMethods(object currentDynamicMethods)
        {
            if (currentDynamicMethods != null)
                return Exception.CopyDynamicMethods(currentDynamicMethods);
            else
                return (object)null;
        }

        [SecuritySafeCritical]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        internal void GetStackTracesDeepCopy(out object currentStackTrace, out object dynamicMethodArray)
        {
            Exception.GetStackTracesDeepCopy(this, out currentStackTrace, out dynamicMethodArray);
        }

        [SecuritySafeCritical]
        internal void RestoreExceptionDispatchInfo(ExceptionDispatchInfo exceptionDispatchInfo)
        {
            if (Exception.IsImmutableAgileException(this))
                return;
            try
            {
            }
            finally
            {
                object currentStackTrace = exceptionDispatchInfo.BinaryStackTraceArray == null ? (object)null : this.DeepCopyStackTrace(exceptionDispatchInfo.BinaryStackTraceArray);
                object dynamicMethodArray = exceptionDispatchInfo.DynamicMethodArray == null ? (object)null : this.DeepCopyDynamicMethods(exceptionDispatchInfo.DynamicMethodArray);
                lock (Exception.s_EDILock)
                {
                    this._watsonBuckets = exceptionDispatchInfo.WatsonBuckets;
                    this._ipForWatsonBuckets = exceptionDispatchInfo.IPForWatsonBuckets;
                    this._remoteStackTraceString = exceptionDispatchInfo.RemoteStackTrace;
                    Exception.SaveStackTracesFromDeepCopy(this, currentStackTrace, dynamicMethodArray);
                }
                this._stackTraceString = (string)null;
                Exception.PrepareForForeignExceptionRaise();
            }
        }

        [SecurityCritical]
        internal virtual string InternalToString()
        {
            try
            {
                new SecurityPermission(SecurityPermissionFlag.ControlEvidence | SecurityPermissionFlag.ControlPolicy).Assert();
            }
            catch
            {
            }
            return this.ToString(true);
        }

        /// <summary>
        /// Gets the runtime type of the current instance.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Type"/> object that represents the exact runtime type of the current instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        [__DynamicallyInvokable]
        public new Type GetType()
        {
            return base.GetType();
        }

        [SecuritySafeCritical]
        internal static string GetMessageFromNativeResources(Exception.ExceptionMessageKind kind)
        {
            string s = (string)null;
            Exception.GetMessageFromNativeResources(kind, JitHelpers.GetStringHandleOnStack(ref s));
            return s;
        }

        private void Init()
        {
            this._message = (string)null;
            this._stackTrace = (object)null;
            this._dynamicMethods = (object)null;
            this.HResult = -2146233088;
            this._xcode = -532462766;
            this._xptrs = (IntPtr)0;
            this._watsonBuckets = (object)null;
            this._ipForWatsonBuckets = UIntPtr.Zero;
            this._safeSerializationManager = new SafeSerializationManager();
        }

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static bool IsImmutableAgileException(Exception e);

        private void AddExceptionDataForRestrictedErrorInfo(string restrictedError, string restrictedErrorReference, string restrictedCapabilitySid, object restrictedErrorObject)
        {
            IDictionary data = this.Data;
            if (data == null)
                return;
            data.Add((object)"RestrictedDescription", (object)restrictedError);
            data.Add((object)"RestrictedErrorReference", (object)restrictedErrorReference);
            data.Add((object)"RestrictedCapabilitySid", (object)restrictedCapabilitySid);
            data.Add((object)"__RestrictedErrorObject", restrictedErrorObject == null ? (object)(Exception.__RestrictedErrorObject)null : (object)new Exception.__RestrictedErrorObject(restrictedErrorObject));
        }

        private string GetClassName()
        {
            if (this._className == null)
                this._className = this.GetType().ToString();
            return this._className;
        }

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static IRuntimeMethodInfo GetMethodFromStackTrace(object stackTrace);

        [SecuritySafeCritical]
        private MethodBase GetExceptionMethodFromStackTrace()
        {
            IRuntimeMethodInfo methodFromStackTrace = Exception.GetMethodFromStackTrace(this._stackTrace);
            if (methodFromStackTrace == null)
                return (MethodBase)null;
            else
                return RuntimeType.GetMethodBase(methodFromStackTrace);
        }

        [SecurityCritical]
        private string GetExceptionMethodString()
        {
            MethodBase targetSiteInternal = this.GetTargetSiteInternal();
            if (targetSiteInternal == (MethodBase)null)
                return (string)null;
            if (targetSiteInternal is DynamicMethod.RTDynamicMethod)
                return (string)null;
            char ch = '\n';
            StringBuilder stringBuilder = new StringBuilder();
            if (targetSiteInternal is ConstructorInfo)
            {
                RuntimeConstructorInfo runtimeConstructorInfo = (RuntimeConstructorInfo)targetSiteInternal;
                Type reflectedType = runtimeConstructorInfo.ReflectedType;
                stringBuilder.Append(1);
                stringBuilder.Append(ch);
                stringBuilder.Append(runtimeConstructorInfo.Name);
                if (reflectedType != (Type)null)
                {
                    stringBuilder.Append(ch);
                    stringBuilder.Append(reflectedType.Assembly.FullName);
                    stringBuilder.Append(ch);
                    stringBuilder.Append(reflectedType.FullName);
                }
                stringBuilder.Append(ch);
                stringBuilder.Append(runtimeConstructorInfo.ToString());
            }
            else
            {
                RuntimeMethodInfo runtimeMethodInfo = (RuntimeMethodInfo)targetSiteInternal;
                Type declaringType = runtimeMethodInfo.DeclaringType;
                stringBuilder.Append(8);
                stringBuilder.Append(ch);
                stringBuilder.Append(runtimeMethodInfo.Name);
                stringBuilder.Append(ch);
                stringBuilder.Append(runtimeMethodInfo.Module.Assembly.FullName);
                stringBuilder.Append(ch);
                if (declaringType != (Type)null)
                {
                    stringBuilder.Append(declaringType.FullName);
                    stringBuilder.Append(ch);
                }
                stringBuilder.Append(runtimeMethodInfo.ToString());
            }
            return ((object)stringBuilder).ToString();
        }

        [SecurityCritical]
        private MethodBase GetExceptionMethodFromString()
        {
            string[] strArray = this._exceptionMethodString.Split(new char[2]
      {
        char.MinValue,
        '\n'
      });
            if (strArray.Length != 5)
                throw new SerializationException();
            SerializationInfo info = new SerializationInfo(typeof(MemberInfoSerializationHolder), (IFormatterConverter)new FormatterConverter());
            info.AddValue("MemberType", (object)int.Parse(strArray[0], (IFormatProvider)CultureInfo.InvariantCulture), typeof(int));
            info.AddValue("Name", (object)strArray[1], typeof(string));
            info.AddValue("AssemblyName", (object)strArray[2], typeof(string));
            info.AddValue("ClassName", (object)strArray[3]);
            info.AddValue("Signature", (object)strArray[4]);
            StreamingContext context = new StreamingContext(StreamingContextStates.All);
            try
            {
                return (MethodBase)new MemberInfoSerializationHolder(info, context).GetRealObject(context);
            }
            catch (SerializationException ex)
            {
                return (MethodBase)null;
            }
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            this._stackTrace = (object)null;
            this._ipForWatsonBuckets = UIntPtr.Zero;
            if (this._safeSerializationManager == null)
                this._safeSerializationManager = new SafeSerializationManager();
            else
                this._safeSerializationManager.CompleteDeserialization((object)this);
        }

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static void PrepareForForeignExceptionRaise();

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static object CopyStackTrace(object currentStackTrace);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static object CopyDynamicMethods(object currentDynamicMethods);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static bool nIsTransient(int hr);

        [SecurityCritical]
        [SuppressUnmanagedCodeSecurity]
        [DllImport("QCall", CharSet = CharSet.Unicode)]
        private static void GetMessageFromNativeResources(Exception.ExceptionMessageKind kind, StringHandleOnStack retMesg);

        [Serializable]
        internal class __RestrictedErrorObject
        {
            [NonSerialized]
            private object _realErrorObject;

            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            internal __RestrictedErrorObject(object errorObject)
            {
                this._realErrorObject = errorObject;
            }
        }

        internal enum ExceptionMessageKind
        {
            ThreadAbort = 1,
            ThreadInterrupted = 2,
            OutOfMemory = 3,
        }
    }
}
