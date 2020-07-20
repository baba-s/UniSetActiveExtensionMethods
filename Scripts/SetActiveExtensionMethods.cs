using System.Collections.Generic;
using UnityEngine;

namespace Kogane
{
	/// <summary>
	/// SetActive 関係の拡張メソッドを管理するクラス
	/// </summary>
	public static class SetActiveExtensionMethods
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// 指定されたすべてのゲームオブジェクトがアクティブかどうかを設定します
		/// </summary>
		public static void SetActiveAll( this IReadOnlyList<GameObject> self, bool isActive )
		{
			for ( var i = 0; i < self.Count; i++ )
			{
				var gameObject = self[ i ];
				gameObject.SetActive( isActive );
			}
		}

		/// <summary>
		/// 指定されたすべてのコンポーネントのゲームオブジェクトがアクティブかどうかを設定します
		/// </summary>
		public static void SetActiveAll( this IReadOnlyList<Component> self, bool isActive )
		{
			for ( var i = 0; i < self.Count; i++ )
			{
				var component  = self[ i ];
				var gameObject = component.gameObject;
				gameObject.SetActive( isActive );
			}
		}

		/// <summary>
		/// 指定されたインデックスに紐づくゲームオブジェクトのみアクティブにします
		/// </summary>
		public static void SetActive( this IReadOnlyList<GameObject> self, int index )
		{
			self.SetActiveAll( false );
			var gameObject = self[ index ];
			gameObject.SetActive( true );
		}

		/// <summary>
		/// 指定されたインデックスに紐づくコンポーネントのゲームオブジェクトのみアクティブにします
		/// </summary>
		public static void SetActive( this IReadOnlyList<Component> self, int index )
		{
			self.SetActiveAll( false );
			var component  = self[ index ];
			var gameObject = component.gameObject;
			gameObject.SetActive( true );
		}

		/// <summary>
		/// 指定されたキーに紐づくゲームオブジェクトのみアクティブにします
		/// </summary>
		public static void SetActive<T>( this IDictionary<T, GameObject> self, T key )
		{
			foreach ( var gameObject in self.Values )
			{
				gameObject.SetActive( false );
			}

			self[ key ].SetActive( true );
		}

		/// <summary>
		/// 指定されたキーに紐づくコンポーネントのゲームオブジェクトのみアクティブにします
		/// </summary>
		public static void SetActive<T>( this IDictionary<T, Component> self, T key )
		{
			foreach ( var component in self.Values )
			{
				component.gameObject.SetActive( false );
			}

			self[ key ].gameObject.SetActive( true );
		}
	}
}