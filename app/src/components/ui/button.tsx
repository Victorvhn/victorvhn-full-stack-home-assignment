import * as React from "react";
import { Slot } from "@radix-ui/react-slot";
import { cva, VariantProps } from "class-variance-authority";

import { cn } from "@/lib/utils";

const buttonVariants = cva("px-4 py-2 focus:outline-none focus:ring-2 focus:ring-offset-2", {
  variants: {
    variant: {
      default:
        "border border-emerald-600 bg-emerald-600 text-white hover:bg-emerald-700 hover:border-emerald-700 focus:ring-emerald-500",
      outline: "border border-gray-300 bg-white text-gray-800 hover:bg-gray-100 focus:ring-gray-300",
    },
  },
  defaultVariants: {
    variant: "default",
  },
});

interface ButtonProps extends React.ComponentProps<"button">, VariantProps<typeof buttonVariants> {
  asChild?: boolean;
}

function Button({ variant, className, asChild = false, children, ...props }: ButtonProps) {
  const Comp = asChild ? Slot : "button";

  return (
    <Comp data-slot="button" className={cn(buttonVariants({ variant, className }))} {...props}>
      {children}
    </Comp>
  );
}

export { Button, type ButtonProps };
