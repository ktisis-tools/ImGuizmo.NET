using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Ktisis.ImGuizmo;

public static class ImGuizmo {

	/**
	 * <summary>Initialize the Gizmo library.</summary>
	 * <param name="imGuiContext">The ImGui context. Obtain from <c>ImGui::GetCurrentContext</c></param>
	 * <param name="allocFunc">The ImGui allocation function. Obtain from <c>ImGui::GetAllocatorFunctions</c></param>
	 * <param name="freeFunc">The ImGui free function. Obtain from <c>ImGui::GetAllocatorFunctions</c></param>
	 * <param name="allocUD">The ImGui allocation userdata. Obtain from <c>ImGui::GetAllocatorFunctions</c></param>
	 */
	 [PublicAPI]
	public static void Initialize(
		IntPtr imGuiContext,
		IntPtr allocFunc, IntPtr freeFunc, IntPtr allocUD
	) {
		NativeInterface.Ktisis_ImGuizmo_SetImGuiContext(imGuiContext);
		NativeInterface.Ktisis_ImGuizmo_SetAllocatorFunctions(allocFunc, freeFunc, allocUD);
	}

	/* AllowAxisFlip defaults to true */
	private static bool _allowAxisFlip = true;

	/**
	 * <summary>
	 * If <c>true</c>, allows the axes to flip towards the camera for easier manipulation.<br/>
	 * If <c>false</c>, forces the axes to always point in the positive direction.
	 * </summary>
	 */
	[PublicAPI]
	public static bool AllowAxisFlip {
		get => _allowAxisFlip;
		set {
			NativeInterface.Ktisis_ImGuizmo_AllowAxisFlip(value);
			_allowAxisFlip = value;
		}
	}

	/* Enable defaults to true */
	private static bool _enable = true;

	/**
	 * <summary>Whether the Gizmo can be used or not. If this is `false`, the Gizmo is drawn with half-transparency.</summary>
	 */
	[PublicAPI]
	public static bool Enable {
		get => _enable;
		set {
			NativeInterface.Ktisis_ImGuizmo_Enable(value);
			_enable = value;
		}
	}

	/** <summary>Whether the Gizmo is in use.</summary> */
	[PublicAPI]
	public static bool IsUsing => NativeInterface.Ktisis_ImGuizmo_IsUsing();
	/** <summary>Whether the cursor is over the Gizmo.</summary> */
	[PublicAPI]
	public static bool IsOver => NativeInterface.Ktisis_ImGuizmo_IsOver0();

	/**
	 * <summary>The DrawList to send commands to. Set to <c>IntPtr.Zero</c> to use the current ImGui Window's DrawList.</summary>
	 */
	[PublicAPI]
	public static IntPtr DrawList {
		set => NativeInterface.Ktisis_ImGuizmo_SetDrawlist(value);
	}

	/**
	 * <summary>Call once at the start of every frame, preferably as early as possible.</summary>
	 */
	[PublicAPI]
	public static void BeginFrame() => NativeInterface.Ktisis_ImGuizmo_BeginFrame();

	/**
	 * <summary>Set the drawing rectangle of the Gizmo.</summary>
	 */
	[PublicAPI]
	public static void SetDrawRect(float x, float y, float width, float height) => NativeInterface.Ktisis_ImGuizmo_SetRect(x, y, width, height);

	[PublicAPI]
	public static unsafe Matrix4x4 RecomposeMatrixFromComponents(Vector3 translation, Vector3 rotation, Vector3 scale) {
		/* Init technically isn't necessary here, but compiler is shouting. */
		Matrix4x4 result = new Matrix4x4();
		NativeInterface.Ktisis_ImGuizmo_RecomposeMatrixFromComponents(
			&translation.X,
			&rotation.X,
			&scale.X,
			&result.M11
		);
		return result;
	}

	[PublicAPI]
	public static unsafe void DecomposeMatrixToComponents(Matrix4x4 matrix, out Vector3 translation, out Vector3 rotation, out Vector3 scale) {
		fixed(Vector3* pTrans = &translation, pRotate = &rotation, pScale = &scale) {
			NativeInterface.Ktisis_ImGuizmo_DecomposeMatrixToComponents(
				&matrix.M11,
				&pTrans->X,
				&pRotate->X,
				&pScale->X
			);
		}
	}

	/** <summary>The current Gizmo style. Cannot be set, but writes to the referenced structure will be reflected in the actual used style.</summary> */
	[PublicAPI]
	public static unsafe ref Style Style => ref *NativeInterface.Ktisis_ImGuizmo_GetStyle();

}
