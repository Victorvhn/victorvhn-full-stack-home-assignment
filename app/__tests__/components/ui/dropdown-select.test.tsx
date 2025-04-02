import React from "react";
import { fireEvent, render, screen, waitFor, within } from "@testing-library/react";
import userEvent from "@testing-library/user-event";

import { DropdownOption, DropdownSelect } from "@/components/ui/dropdown-select";

const options: DropdownOption[] = [
  { value: "1", label: "Option A" },
  { value: "2", label: "Option B" },
  { value: "3", label: "Option C" },
  { value: "4", label: "Option D" },
];

const renderDropdown = (props = {}) => render(<DropdownSelect label="Test Label" options={options} {...props} />);

describe("DropdownSelect", () => {
  test("should render label and display the correct selected option when provided a value", () => {
    renderDropdown({ value: "2" });

    expect(screen.getByText(/Test Label/i)).toBeInTheDocument();
    expect(screen.getByRole("combobox")).toHaveTextContent("Option B");
  });

  test("should open the dropdown and display all available options when clicked", async () => {
    renderDropdown({ value: "2" });
    const combobox = screen.getByRole("combobox");
    await userEvent.click(combobox);

    const optionsContainer = await screen.findByTestId("dropdown-options");
    expect(within(optionsContainer).getByText("Option A")).toBeInTheDocument();
    expect(within(optionsContainer).getByText("Option B")).toBeInTheDocument();
    expect(within(optionsContainer).getByText("Option C")).toBeInTheDocument();
    expect(within(optionsContainer).getByText("Option D")).toBeInTheDocument();
  });

  test("should filter options based on the entered search term", async () => {
    renderDropdown();
    const combobox = screen.getByRole("combobox");
    await userEvent.click(combobox);

    const searchInput = await screen.findByTestId("search-input");
    await userEvent.type(searchInput, "Option B");

    const optionsContainer = await screen.findByTestId("dropdown-options");

    await waitFor(() => {
      expect(within(optionsContainer).queryByText("Option A")).not.toBeInTheDocument();
      expect(within(optionsContainer).getByText("Option B")).toBeInTheDocument();
      expect(within(optionsContainer).queryByText("Option C")).not.toBeInTheDocument();
      expect(within(optionsContainer).queryByText("Option D")).not.toBeInTheDocument();
    });
  });

  test("should select an option on click and call the onChange callback with the correct value", async () => {
    const onChangeMock = jest.fn();
    renderDropdown({ onChange: onChangeMock });
    const combobox = screen.getByRole("combobox");
    await userEvent.click(combobox);

    const optionsContainer = await screen.findByTestId("dropdown-options");
    const optionA = within(optionsContainer).getByText("Option A");
    await userEvent.click(optionA);

    await waitFor(() => {
      expect(onChangeMock).toHaveBeenCalledWith("1");
    });
  });

  describe("Keyboard interactions", () => {
    test("should navigate options using keyboard arrows and select an option with the Enter key", async () => {
      // Mock scrollIntoView to prevent errors in the test environment.
      Element.prototype.scrollIntoView = jest.fn();
      const onChangeMock = jest.fn();
      renderDropdown({ value: "1", onChange: onChangeMock });
      const combobox = screen.getByRole("combobox");

      await userEvent.click(combobox);
      await userEvent.keyboard("{arrowdown}{arrowdown}{arrowup}{enter}");

      await waitFor(() => {
        expect(onChangeMock).toHaveBeenCalledWith("2");
      });
    });

    test("should open the dropdown when the Space key is pressed on a focused combobox", async () => {
      renderDropdown();
      const combobox = screen.getByRole("combobox");
      combobox.focus();

      await userEvent.keyboard("{ }");

      await waitFor(() => {
        expect(screen.getByTestId("dropdown-options")).toBeInTheDocument();
      });
    });

    test("should open the dropdown when the Enter key is pressed on a focused combobox", async () => {
      renderDropdown();
      const combobox = screen.getByRole("combobox");
      combobox.focus();

      await userEvent.keyboard("{enter}");

      await waitFor(() => {
        expect(screen.getByTestId("dropdown-options")).toBeInTheDocument();
      });
    });
  });

  test("should close the dropdown when the Escape key is pressed", async () => {
    renderDropdown({ onChange: () => {} });
    const combobox = screen.getByRole("combobox");
    await userEvent.click(combobox);

    expect(await screen.findByTestId("dropdown-options")).toBeInTheDocument();

    await fireEvent.keyDown(combobox, { key: "Escape", code: "Escape" });

    await waitFor(() => {
      expect(screen.queryByTestId("dropdown-options")).not.toBeInTheDocument();
    });
  });

  test("should close the dropdown when a click occurs outside the component", async () => {
    render(
      <div>
        <DropdownSelect label="Test Label" options={options} onChange={() => {}} />
        <button data-testid="outside-btn">Outside</button>
      </div>
    );
    const combobox = screen.getByRole("combobox");
    await userEvent.click(combobox);
    expect(await screen.findByTestId("dropdown-options")).toBeInTheDocument();

    const outsideBtn = screen.getByTestId("outside-btn");
    await userEvent.click(outsideBtn);

    await waitFor(() => {
      expect(screen.queryByTestId("dropdown-options")).not.toBeInTheDocument();
    });
  });

  test("should update the displayed selected option when the value prop changes", async () => {
    const { rerender } = renderDropdown({ value: "1" });

    expect(screen.getByRole("combobox")).toHaveTextContent("Option A");

    rerender(<DropdownSelect label="Test Label" options={options} value="2" />);

    await waitFor(() => {
      expect(screen.getByRole("combobox")).toHaveTextContent("Option B");
    });
  });

  test("should focus the combobox when its label is clicked", async () => {
    renderDropdown();

    const combobox = screen.getByRole("combobox");
    expect(combobox).not.toHaveFocus();

    const label = screen.getByText("Test Label");
    await userEvent.click(label);

    await waitFor(() => {
      expect(combobox).toHaveFocus();
    });
  });

  test("should render a label with a matching htmlFor attribute that corresponds to the combobox id", () => {
    renderDropdown({ value: "1" });

    const label = screen.getByText("Test Label");
    const combobox = screen.getByRole("combobox");

    expect(label).toHaveAttribute("for", expect.stringMatching(/dropdown-/));
    expect(combobox).toHaveAttribute("id", expect.stringMatching(/dropdown-/));
  });

  test("should clear the selected option if it is removed from the options list", async () => {
    const { rerender } = renderDropdown({ value: "2" });

    expect(screen.getByRole("combobox")).toHaveTextContent("Option B");

    const updatedOptions = options.filter((option) => option.value !== "2");

    rerender(<DropdownSelect label="Test Label" options={updatedOptions} value="2" />);

    await waitFor(() => {
      expect(screen.getByRole("combobox")).not.toHaveTextContent("Option B");
    });
  });
});
