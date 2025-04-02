"use client";

import React, { useEffect, useId, useLayoutEffect, useRef, useState } from "react";
import { ChevronDown, ChevronUp } from "lucide-react";

import { cn } from "@/lib/utils";

export interface DropdownOption {
  value: string;
  label: string;
}

interface DropdownSelectProps extends Omit<React.ComponentProps<"div">, "onChange"> {
  label?: string;
  options: DropdownOption[];
  value?: string;
  onChange?: (option: string) => void;
  id?: string;
}

export function DropdownSelect({ label = "", options, value, onChange, id: externalId, ...rest }: DropdownSelectProps) {
  const internalId = useId();
  const dropdownId = externalId || `dropdown-${internalId}`;

  const [isOpen, setIsOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");
  const [selectedOption, setSelectedOption] = useState<DropdownOption | null>(
    options.find((option) => option.value === value) || null
  );

  const [keyboardHighlightedIndex, setKeyboardHighlightedIndex] = useState(0);
  const [isKeyboardNavigationActive, setIsKeyboardNavigationActive] = useState(false);

  const containerRef = useRef<HTMLDivElement>(null);
  const comboboxRef = useRef<HTMLDivElement>(null);
  const searchTermInputRef = useRef<HTMLInputElement>(null);
  const optionsContainerRef = useRef<HTMLDivElement>(null);
  const highlightedItemRef = useRef<HTMLLIElement>(null);
  const selectedItemRef = useRef<HTMLLIElement>(null);

  const filteredOptions = options.filter((option) =>
    option.label.toLowerCase().includes(searchTerm.trim().toLowerCase())
  );

  const resetDropdown = () => {
    setIsOpen(false);
    setSearchTerm("");
    setIsKeyboardNavigationActive(false);
    setKeyboardHighlightedIndex(0);
  };

  // Effect to reset the dropdown when options change
  useEffect(() => {
    resetDropdown();

    if (selectedOption) {
      const stillExists = options.some((option) => option.value === selectedOption.value);
      if (!stillExists) {
        setSelectedOption(null);
      }
    }
  }, [options, selectedOption]);

  // Effect to update the dropdown when the value prop changes
  useEffect(() => {
    if (!value) {
      setSelectedOption(null);
    }

    const matchingOption = options.find((option) => option.value === value);
    if (matchingOption) {
      setSelectedOption(matchingOption);
    }
  }, [value, options]);

  // Effect to reset the state when the dropdown is closed
  useEffect(() => {
    if (isOpen) {
      return;
    }

    resetDropdown();
  }, [isOpen]);

  // Effect to reset highlighted index when filtered options change
  useEffect(() => {
    setKeyboardHighlightedIndex(0);
  }, [filteredOptions.length]);

  // Effect to register the click outside event
  useEffect(() => {
    function handleClickOutside(event: MouseEvent) {
      if (containerRef.current && !containerRef.current.contains(event.target as Node)) {
        setIsOpen(false);
      }
    }

    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  // Effect to ensure the selected option is visible when the dropdown opens
  useLayoutEffect(() => {
    if (!isOpen) {
      return;
    }

    if (searchTermInputRef.current) {
      searchTermInputRef.current.focus();
    }

    if (selectedOption && selectedItemRef.current && optionsContainerRef.current) {
      const SEARCH_BAR_HEIGHT = 59;
      const scrollTop = selectedItemRef.current.offsetTop - SEARCH_BAR_HEIGHT;
      optionsContainerRef.current.scrollTop = scrollTop > 0 ? scrollTop : 0;
    }
  }, [isOpen, selectedOption]);

  // Effect to ensure the highlighted item is always visible when navigating with keyboard
  useEffect(() => {
    if (!isOpen || !isKeyboardNavigationActive || !highlightedItemRef.current || !optionsContainerRef.current) {
      return;
    }

    highlightedItemRef.current.scrollIntoView({
      block: "nearest",
      behavior: "auto",
    });
  }, [keyboardHighlightedIndex, isOpen, isKeyboardNavigationActive]);

  // Handle the selection of an option
  const handleSelectOption = (option: DropdownOption) => {
    setSelectedOption(option);

    if (onChange) {
      onChange(option.value);
    }

    setIsOpen(false);
  };

  // Handle keyboard navigation
  const handleKeyDown = (event: React.KeyboardEvent) => {
    if (!isOpen) {
      return;
    }

    switch (event.key) {
      case "ArrowDown":
        event.preventDefault();
        setIsKeyboardNavigationActive(true);
        setKeyboardHighlightedIndex((prev) => (prev < filteredOptions.length - 1 ? prev + 1 : prev));
        break;
      case "ArrowUp":
        event.preventDefault();
        setIsKeyboardNavigationActive(true);
        setKeyboardHighlightedIndex((prev) => (prev > 0 ? prev - 1 : 0));
        break;
      case "Enter":
        event.preventDefault();
        if (filteredOptions[keyboardHighlightedIndex]) {
          handleSelectOption(filteredOptions[keyboardHighlightedIndex]);
        }
        break;
      case "Escape":
        event.preventDefault();
        setIsOpen(false);
        break;
    }
  };

  // Handle dropdown toggle
  const handleDropdownToggle = () => {
    setIsOpen((prev) => {
      if (prev == true || !selectedOption) {
        return !prev;
      }

      const selectedIndex = filteredOptions.findIndex((option) => option.value === selectedOption.value);
      if (selectedIndex >= 0) {
        setKeyboardHighlightedIndex(selectedIndex);
      }

      return !prev;
    });
  };

  // Handle dropdown keydown events
  const handleDropdownKeyDown = (event: React.KeyboardEvent) => {
    if (event.key === " " || event.key === "Enter") {
      event.preventDefault();
      handleDropdownToggle();
    }
  };

  // Handle label click to focus the combobox
  const handleLabelClick = (event: React.MouseEvent) => {
    event.preventDefault();

    if (comboboxRef.current) {
      comboboxRef.current.focus();
    }
  };

  return (
    <div {...rest}>
      {label && (
        <label
          htmlFor={dropdownId}
          className="mb-2 block text-sm font-medium text-gray-700 dark:text-gray-300"
          onClick={handleLabelClick}
        >
          {label}
        </label>
      )}
      <div className="relative" ref={containerRef} onKeyDown={handleKeyDown}>
        <div
          id={dropdownId}
          ref={comboboxRef}
          role="combobox"
          aria-expanded={isOpen}
          aria-haspopup="listbox"
          aria-controls={`${dropdownId}-listbox`}
          aria-label={label || "Dropdown"}
          tabIndex={0}
          className="flex w-full cursor-pointer items-center justify-between border border-gray-300 bg-white px-3 py-2 hover:bg-gray-100 focus:ring-2 focus:ring-emerald-500 focus:outline-none"
          onClick={handleDropdownToggle}
          onKeyDown={handleDropdownKeyDown}
        >
          <span className="text-gray-900">{selectedOption && selectedOption.label}</span>
          {isOpen ? <ChevronUp className="h-5 w-5 text-gray-400" /> : <ChevronDown className="h-5 w-5 text-gray-400" />}
        </div>

        {isOpen && (
          <div
            role="listbox"
            data-testid="dropdown-options"
            className="group absolute z-10 mt-1 w-full border border-gray-300 bg-white opacity-100 shadow-lg transition-opacity duration-75"
          >
            <div className="sticky top-0 z-10 border-b border-gray-300 bg-white p-2">
              <input
                data-testid="search-input"
                ref={searchTermInputRef}
                type="text"
                className="w-full border border-gray-300 px-3 py-2 focus:ring-2 focus:ring-emerald-500 focus:outline-none"
                placeholder="Search..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
              />
            </div>

            <div className="max-h-60 overflow-scroll pt-1" ref={optionsContainerRef}>
              {filteredOptions.length > 0 ? (
                <ul>
                  {filteredOptions.map((option, index) => (
                    <li
                      key={option.value}
                      ref={
                        selectedOption && option.value === selectedOption.value
                          ? selectedItemRef
                          : keyboardHighlightedIndex === index
                            ? highlightedItemRef
                            : null
                      }
                      className={cn(
                        "cursor-pointer px-3 py-2",
                        keyboardHighlightedIndex === index && "bg-emerald-100",
                        option.value === selectedOption?.value &&
                          "border-l-4 border-emerald-500 bg-emerald-50 font-medium"
                      )}
                      onClick={() => handleSelectOption(option)}
                      onMouseEnter={() => setKeyboardHighlightedIndex(index)}
                    >
                      {option.label}
                    </li>
                  ))}
                </ul>
              ) : (
                <div className="px-3 py-4 text-center text-gray-500">No options found</div>
              )}
            </div>
          </div>
        )}
      </div>
    </div>
  );
}
