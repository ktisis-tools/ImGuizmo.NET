CXXFLAGS := -std=c++11 -IImGui/ -fPIC
CXXLDFLAGS := -static-libgcc -static-libstdc++ -shared

-include common.mak

# (run_command, tag, path, preflags, source, postflags)
ifdef make_info
define run_command
	@$(make_info) $(1) $@ $(4) ';' $? ';'
	@$(2) $(3) $@ $(4) $(5)
endef
else
define run_command
	$(2) $(3) $@ $(4) $(5)
endef
endif

.DEFAULT_GOAL := build

ifeq ($(OS),Windows_NT)
os_target := ImGuizmo-Bridge.dll
else
os_target := libImGuizmo-Bridge.so
endif

ifndef write_file
$(info Using shell auto-detection to determine the correct commands / args for your shell.)
$(info (Supply `write_file` and `echo_empty` if generating the license fails))
ifeq ($(shell echo %COMSPEC%), %COMSPEC%)
$(info Detected POSIX-compatible shell.)
write_file := cat
echo_empty := echo

define ensure_dir
	@mkdir -p $(1)
endef
else
$(info Detected Windows cmd.exe.)
write_file := type
echo_empty := echo.

define ensure_dir
	@if not exist "$(1)" ( mkdir "$(1)" )
endef
endif

endif

.PHONY: clean build

IMGUI_OBJS := $(addprefix ImGui/obj/, imgui.o imgui_tables.o imgui_widgets.o imgui_draw.o)
IMGUIZMO_OBJS := $(addprefix ImGuizmo/obj/, ImGuizmo.o GraphEditor.o ImCurveEdit.o ImGradient.o ImSequencer.o)
BRIDGE_OBJS := $(addprefix ImGuizmo.Bridge/obj/, bridge.o)

ImGui/obj/%.o: ImGui/%.cpp ImGui/imgui.h ImGui/imgui_internal.h
	$(call ensure_dir,$(@D))
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS))

ImGuizmo/obj/%.o: ImGuizmo/%.cpp ImGuizmo/%.h ImGui/imgui.h ImGui/imgui_internal.h
	$(call ensure_dir,$(@D))
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS))

ImGuizmo/obj/%.o: ImGuizmo/%.cpp ImGui/imgui.h ImGui/imgui_internal.h
	$(call ensure_dir,$(@D))
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS))

ImGuizmo.Bridge/obj/%.o: ImGuizmo.Bridge/src/%.cpp ImGuizmo.Bridge/include/%.h
	$(call ensure_dir,$(@D))
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS) -IImGuizmo.Bridge/include)

ImGuizmo.Bridge/obj/%.o: ImGuizmo.Bridge/src/%.cpp
	$(call ensure_dir,$(@D))
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS) -IImGuizmo.Bridge/include)


libImGuizmo-Bridge.so: $(IMGUI_OBJS) $(IMGUIZMO_OBJS) $(BRIDGE_OBJS)
	$(call run_command, CXXLD, $(CXX), -o, $^, $(CXXFLAGS) $(CXXLDFLAGS))

ImGuizmo-Bridge.dll: $(IMGUI_OBJS) $(IMGUIZMO_OBJS) $(BRIDGE_OBJS)
	$(call run_command, CXXLD, $(CXX), -o, $^, $(CXXFLAGS) $(CXXLDFLAGS) -mwindows)

build: ImGuizmo-Bridge.LICENSE.txt $(os_target)

ImGuizmo-Bridge.LICENSE.txt: ../LICENSE ImGui/LICENSE.txt ImGuizmo/LICENSE
ifdef make_info
	@$(make_info) CAT $@ $^ ';' $? ';'
else
	@echo Generating ImGuizmo-Bridge.LICENSE.txt...
endif
	@$(write_file) ../LICENSE > $@
	@$(echo_empty) >> $@
	@echo Contains code from ImGui, licensed under the following terms: >> $@
	@$(echo_empty) >> $@
	@$(write_file) ImGui/LICENSE.txt >> $@
	@$(echo_empty) >> $@
	@echo Contains code from ImGuizmo, licensed under the following terms: >> $@
	@$(echo_empty) >> $@
	@$(write_file) ImGuizmo/LICENSE >> $@

clean:
	$(RM) -rf ImGui/obj/
	$(RM) -rf ImGuizmo/obj/
	$(RM) -rf ImGuizmo.Bridge/obj/
	$(RM) libImGuizmo-Bridge.so
	$(RM) ImGuizmo-Bridge.dll
	$(RM) ImGuizmo-Bridge.LICENSE.txt
