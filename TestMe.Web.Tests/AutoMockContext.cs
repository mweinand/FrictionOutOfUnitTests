namespace Centare.Testing
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using Moq.AutoMock;

	/// <summary>
	/// Provides a context for all interaction tests.
	/// </summary>
	/// <typeparam name="TClassToTest">The class for which the interaction tests are created.</typeparam>
	public class AutoMockContext<TClassToTest>
		where TClassToTest : class
	{
		/// <summary>
		/// AutoMocker container field
		/// </summary>
		private AutoMocker container;

		/// <summary>
		/// Initializes a new instance of the <see cref="AutoMockContext{TClassToTest}"/> class.
		/// </summary>
		public AutoMockContext()
		{
		}

		/// <summary>
		/// Gets the instance of the class being testing.
		/// </summary>
		public TClassToTest ClassUnderTest
		{
			get
			{
				return this.container.Get<TClassToTest>();
			}
		}

		/// <summary>
		/// Returns the current mocked instance for the specified <typeparamref name="TService"/>.
		/// </summary>
		/// <typeparam name="TService">The type of mocked instance to retrieve.</typeparam>
		/// <returns>Returns a Mock</returns>
		public Mock<TService> MockFor<TService>()
			where TService : class
		{
			return this.container.GetMock<TService>();
		}

		/// <summary>
		/// Verifies all expectations for the specified <typeparamref name="TService"/>.
		/// </summary>
		/// <typeparam name="TService">The type of mocked instance to verify.</typeparam>
		public void VerifyCallsFor<TService>()
			where TService : class
		{
			this.MockFor<TService>().VerifyAll();
		}

		/// <summary>
		/// Called by the NUnit framework to perform setup tasks.
		/// Context-specific setup tasks should be implemented by overriding the <see cref="BeforeEach"/> method.
		/// </summary>
		[TestInitialize]
		public void SetUp()
		{
			this.container = new AutoMocker();
			this.container.Use<TClassToTest>(this.container.CreateInstance<TClassToTest>());

			this.BeforeEach();
		}

		/// <summary>
		/// Called after setup tasks are performed in the <see cref="SetUp"/> method.
		/// </summary>
		protected virtual void BeforeEach()
		{
		}
	}
}
