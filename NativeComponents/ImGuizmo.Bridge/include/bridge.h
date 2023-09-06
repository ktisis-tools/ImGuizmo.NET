#pragma once

#include "imgui.h"
#include "../ImGuizmo/ImGuizmo.h"

#if __GNUC__
#define MAYBE_UNUSED __attribute__((unused))
#else
#define MAYBE_UNUSED
#endif

#if defined _WIN32 || defined __CYGWIN__
	#define BRIDGE_API __declspec(dllexport) MAYBE_UNUSED extern
#elif __GNUC__
	#define BRIDGE_API __attribute__(( visibility("default") )) MAYBE_UNUSED extern
#else
	#define BRIDGE_API MAYBE_UNUSED extern
#endif

extern "C" {

/* Init functions */
BRIDGE_API void Ktisis_ImGuizmo_SetImGuiContext(ImGuiContext* ctx);
BRIDGE_API void Ktisis_ImGuizmo_SetAllocatorFunctions(ImGuiMemAllocFunc alloc, ImGuiMemFreeFunc free, void* ud);

/* Utility functions */
BRIDGE_API void Ktisis_ImGuizmo_DecomposeMatrixToComponents(const float* matrix, float* translation, float* rotation, float* scale);
BRIDGE_API void Ktisis_ImGuizmo_RecomposeMatrixFromComponents(const float* translation, const float* rotation, const float* scale, float* matrix);

BRIDGE_API ImGuizmo::Style* Ktisis_ImGuizmo_GetStyle();

/* 'Work' functions */
BRIDGE_API void Ktisis_ImGuizmo_AllowAxisFlip(bool value);
BRIDGE_API void Ktisis_ImGuizmo_BeginFrame();
BRIDGE_API void Ktisis_ImGuizmo_SetDrawlist(ImDrawList* drawList);
BRIDGE_API void Ktisis_ImGuizmo_SetRect(float x, float y, float width, float height);
BRIDGE_API void Ktisis_ImGuizmo_SetID(int id);
BRIDGE_API void Ktisis_ImGuizmo_SetGizmoSizeClipSpace(float value);
BRIDGE_API void Ktisis_ImGuizmo_Enable(bool enabled);
BRIDGE_API bool Ktisis_ImGuizmo_Manipulate(
	const float* view,
	const float* projection,
	ImGuizmo::OPERATION operation,
	ImGuizmo::MODE mode,
	float* matrix,
	float* deltaMatrix,
	const float* snap,
	const float* localBounds,
	const float* boundsSnap
);

BRIDGE_API bool Ktisis_ImGuizmo_IsUsing();
BRIDGE_API bool Ktisis_ImGuizmo_IsOver0();

}
