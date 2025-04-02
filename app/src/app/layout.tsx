import type { Metadata } from "next";

import "./globals.css";

import { NuqsAdapter } from "nuqs/adapters/next";

export const metadata: Metadata = {
  title: "Family Tree",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <NuqsAdapter>{children}</NuqsAdapter>
      </body>
    </html>
  );
}
